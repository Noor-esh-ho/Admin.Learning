using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Tool;
using Learning.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Learning.Infrastructure.Dto;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Learning.Repository;
using Learning.Service.Base;
using Learning.Service;

namespace Learning.Api_Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LearningContext>(options =>
            {
                var connString = Configuration["ConnectionStrings:default"];
                options.UseSqlServer(connString);//使用配置文件中的连接字符串
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // services.AddSingleton<>();//相当于单例模式，每次请求都是同一个实例
            // services.AddTransient<>();//每次请求都会创建一个新的对象new()
            //services.AddScoped<>();//每次请求获取的都是新的实例，但线程内都是同一个实例

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<DbContext,LearningContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Learning.Repository.SqlRepository<>));



            #region JWT Auth
            string jwtKey = Configuration["JWT:issuer"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,//是否验证Issuer
                     ValidateAudience = true,//是否验证Audience
                     ValidateLifetime = true,//是否验证失效时间
                     ValidateIssuerSigningKey = true,//是否验证SecurityKey
                     ValidAudience = jwtKey,//Audience
                     ValidIssuer = jwtKey,//Issuer，这两项和后面签发jwt的设置一致
                     ClockSkew = TimeSpan.Zero, // // 默认允许 300s  的时间偏移量，设置为0
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))//拿到SecurityKey
                 };
                 options.Events = new JwtBearerEvents
                 {
                     //自定义验证规则
                     OnMessageReceived = context =>
                     {
                         if (!StringValues.IsNullOrEmpty(context.Request.Headers["Authorization"]))
                         {
                             try
                             {

                                 //todo  验证多app登陆
                                 var startLength = "Bearer ".Length;
                                 var tokenStr = context.Request.Headers["Authorization"].ToString();
                                 //if (tokenStr.IndexOf("Bearer") == -1) //正式环境请务必注释
                                 //{
                                 //    var token = GetTempToken(tokenStr);
                                 //    context.Request.Headers["Authorization"] = "Bearer " + token;
                                 //}
                                 //else
                                 //{
                                 //验证权限
                                 var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenStr.Substring(startLength, tokenStr.Length - startLength));
                                 //得到保存的code 验证code是否过期
                                 string code = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
                                 var result = CheckLoginCode(code);
                                 if (!result)
                                 {
                                     context.Request.Headers["Authorization"] = string.Empty; //登录过期 清空token 让其返回401
                                 }
                                 // }
                                 //var user = iq.SingleOrDefault();

                                 //此处再做权限验证 验证用户是否拥有权限
                                 //此处可以将code 换回为uid 方便后续操作 未完成
                             }
                             catch (Exception ex)
                             {
                                 context.Request.Headers["Authorization"] = string.Empty;
                             }

                         }
                         return Task.CompletedTask;
                     }

                 };
             });

            #endregion

            #region Cors跨域请求
            services.AddCors(c =>
            {
                c.AddPolicy("AllRequests", policy =>
                {
                    policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            #endregion

            RegisterService(services);
            services.AddControllers();

            #region 配置swagger
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Title = "Learning.Api_Admin",
                      Version = "v1.0",
                      Description = "云上学堂.接口文档",
                      License = new OpenApiLicense
                      {
                          Name = "Author:Ase",
                      }
                  });


                  c.SwaggerDoc("Base", new OpenApiInfo { Title = "基础模块", Version = "Base" });   //分组显示
                  c.SwaggerDoc("Exam", new OpenApiInfo { Title = "考试模块", Version = "Exam" });   //分组显示
                  c.SwaggerDoc("Right", new OpenApiInfo { Title = "权限模块", Version = "Right" });   //分组显示
                  c.SwaggerDoc("Organization", new OpenApiInfo { Title = "组织模块", Version = "Organization" });
                  c.SwaggerDoc("Attribute", new OpenApiInfo { Title = "属性模块", Version = "Attribute" });
                  string basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                  string xmlPath = Path.Combine(basePath, "Learning.Api_Admin.xml");
                  c.IncludeXmlComments(xmlPath, true);

                  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                  {
                      Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格,正确格式为 Bearer+空格+Token）\"",
                      Name = "Authorization",//jwt默认的参数名称
                      In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                      Type = SecuritySchemeType.ApiKey
                  });

                  c.AddSecurityRequirement(new OpenApiSecurityRequirement {

                {
                 new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference()
                {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
                }
                }, Array.Empty<string>() }
                  });
              });
        }
        #endregion

        public bool CheckLoginCode(string code)
        {
            //查询数据库 并判断是否过期
            //var dbcountex = Configuration["ConnectionStrings:default"];
            //var usersService = new UserService(new BaseUserService(new SqlRepository<Infrastructure.Dto.Models.User>(new Infrastructure.Dto.Models.LearningContext(Configuration["ConnectionStrings:default"])), Configuration));
            //var user = usersService.GetUserByCode(code);
            return true;
        }
        private void RegisterService(IServiceCollection services)
        {
            //批量注入
            services.AddTransient(Assembly.Load("Learning.Service.Interface"), Assembly.Load("Learning.Service"));
            services.AddTransient(Assembly.Load("Learning.Service.Base"), Assembly.Load("Learning.Service.Base"));
            services.AddTransient(Assembly.Load("Learning.Infrastructure.IOC"), Assembly.Load("Learning.Infrastructure.IOC"));



            #region 废弃的代码

            #region 注入上下文2（注释）
            //services.AddDbContext<Learning.Infrastructure.Dto.OnLineExamContext>(options =>
            //{
            //    string connString = Configuration["ConnectionStrings:default"];
            //    options.UseSqlServer(connString); //使用配置文件中的连接字符串
            //    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //}); 
            #endregion

            #region 未管理时的注入写法
            //注入上下文(若有两个，则会自动注入第二个，若在你的页面要用第一个Learning.Infrastructure.Dto.OnLineExamContextLeaning.Model.OnLineExamContext>();
            // services.AddTransient<DbContext,OnLineExamContext>();

            //typeof(Leaning.DAL.IRepository<>)父类（基类）， typeof(Leaning.DAL.SqlRepository<>)子类（继承类）
            //services.AddTransient(typeof(IRepository<>), typeof(SqlRepository<>));//注入仓储
            //services.AddSession();
            services.AddHttpContextAccessor();//访问器对象

            //断子绝孙模式
            //services.AddTransient<Learning.Service.Base.BaseUserService>();
            //services.AddTransient<IUserService, Learning.Service.UserService>(); 
            #endregion

            #region 用户模块
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<UserIOC>();
            //services.AddTransient<BaseUserService>();//注册users表
            //services.AddTransient<BaseUserInfoService>();//注册userinfo表
            #endregion

            #endregion
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            //app.UseSession();//开启session
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning.Api_Admin v1"));
                app.UseSwaggerUI(c =>
                {

                    c.SwaggerEndpoint("/swagger/Base/swagger.json", "基础模块");
                    c.SwaggerEndpoint("/swagger/Exam/swagger.json", "考试模块");
                    c.SwaggerEndpoint("/swagger/Right/swagger.json", "权限模块"); 
                    c.SwaggerEndpoint("/swagger/Organization/swagger.json", "组织模块");
                    c.SwaggerEndpoint("/swagger/Attribute/swagger.json", "属性模块");
                });
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
