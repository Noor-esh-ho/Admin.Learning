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
                options.UseSqlServer(connString);//ʹ�������ļ��е������ַ���
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // services.AddSingleton<>();//�൱�ڵ���ģʽ��ÿ��������ͬһ��ʵ��
            // services.AddTransient<>();//ÿ�����󶼻ᴴ��һ���µĶ���new()
            //services.AddScoped<>();//ÿ�������ȡ�Ķ����µ�ʵ�������߳��ڶ���ͬһ��ʵ��

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
                     ValidateIssuer = true,//�Ƿ���֤Issuer
                     ValidateAudience = true,//�Ƿ���֤Audience
                     ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                     ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                     ValidAudience = jwtKey,//Audience
                     ValidIssuer = jwtKey,//Issuer��������ͺ���ǩ��jwt������һ��
                     ClockSkew = TimeSpan.Zero, // // Ĭ������ 300s  ��ʱ��ƫ����������Ϊ0
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))//�õ�SecurityKey
                 };
                 options.Events = new JwtBearerEvents
                 {
                     //�Զ�����֤����
                     OnMessageReceived = context =>
                     {
                         if (!StringValues.IsNullOrEmpty(context.Request.Headers["Authorization"]))
                         {
                             try
                             {

                                 //todo  ��֤��app��½
                                 var startLength = "Bearer ".Length;
                                 var tokenStr = context.Request.Headers["Authorization"].ToString();
                                 //if (tokenStr.IndexOf("Bearer") == -1) //��ʽ���������ע��
                                 //{
                                 //    var token = GetTempToken(tokenStr);
                                 //    context.Request.Headers["Authorization"] = "Bearer " + token;
                                 //}
                                 //else
                                 //{
                                 //��֤Ȩ��
                                 var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenStr.Substring(startLength, tokenStr.Length - startLength));
                                 //�õ������code ��֤code�Ƿ����
                                 string code = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
                                 var result = CheckLoginCode(code);
                                 if (!result)
                                 {
                                     context.Request.Headers["Authorization"] = string.Empty; //��¼���� ���token ���䷵��401
                                 }
                                 // }
                                 //var user = iq.SingleOrDefault();

                                 //�˴�����Ȩ����֤ ��֤�û��Ƿ�ӵ��Ȩ��
                                 //�˴����Խ�code ����Ϊuid ����������� δ���
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

            #region Cors��������
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

            #region ����swagger
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Title = "Learning.Api_Admin",
                      Version = "v1.0",
                      Description = "����ѧ��.�ӿ��ĵ�",
                      License = new OpenApiLicense
                      {
                          Name = "Author:Ase",
                      }
                  });


                  c.SwaggerDoc("Base", new OpenApiInfo { Title = "����ģ��", Version = "Base" });   //������ʾ
                  c.SwaggerDoc("Exam", new OpenApiInfo { Title = "����ģ��", Version = "Exam" });   //������ʾ
                  c.SwaggerDoc("Right", new OpenApiInfo { Title = "Ȩ��ģ��", Version = "Right" });   //������ʾ
                  c.SwaggerDoc("Organization", new OpenApiInfo { Title = "��֯ģ��", Version = "Organization" });
                  c.SwaggerDoc("Attribute", new OpenApiInfo { Title = "����ģ��", Version = "Attribute" });
                  string basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                  string xmlPath = Path.Combine(basePath, "Learning.Api_Admin.xml");
                  c.IncludeXmlComments(xmlPath, true);

                  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                  {
                      Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�,��ȷ��ʽΪ Bearer+�ո�+Token��\"",
                      Name = "Authorization",//jwtĬ�ϵĲ�������
                      In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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
            //��ѯ���ݿ� ���ж��Ƿ����
            //var dbcountex = Configuration["ConnectionStrings:default"];
            //var usersService = new UserService(new BaseUserService(new SqlRepository<Infrastructure.Dto.Models.User>(new Infrastructure.Dto.Models.LearningContext(Configuration["ConnectionStrings:default"])), Configuration));
            //var user = usersService.GetUserByCode(code);
            return true;
        }
        private void RegisterService(IServiceCollection services)
        {
            //����ע��
            services.AddTransient(Assembly.Load("Learning.Service.Interface"), Assembly.Load("Learning.Service"));
            services.AddTransient(Assembly.Load("Learning.Service.Base"), Assembly.Load("Learning.Service.Base"));
            services.AddTransient(Assembly.Load("Learning.Infrastructure.IOC"), Assembly.Load("Learning.Infrastructure.IOC"));



            #region �����Ĵ���

            #region ע��������2��ע�ͣ�
            //services.AddDbContext<Learning.Infrastructure.Dto.OnLineExamContext>(options =>
            //{
            //    string connString = Configuration["ConnectionStrings:default"];
            //    options.UseSqlServer(connString); //ʹ�������ļ��е������ַ���
            //    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //}); 
            #endregion

            #region δ����ʱ��ע��д��
            //ע��������(��������������Զ�ע��ڶ������������ҳ��Ҫ�õ�һ��Learning.Infrastructure.Dto.OnLineExamContextLeaning.Model.OnLineExamContext>();
            // services.AddTransient<DbContext,OnLineExamContext>();

            //typeof(Leaning.DAL.IRepository<>)���ࣨ���ࣩ�� typeof(Leaning.DAL.SqlRepository<>)���ࣨ�̳��ࣩ
            //services.AddTransient(typeof(IRepository<>), typeof(SqlRepository<>));//ע��ִ�
            //services.AddSession();
            services.AddHttpContextAccessor();//����������

            //���Ӿ���ģʽ
            //services.AddTransient<Learning.Service.Base.BaseUserService>();
            //services.AddTransient<IUserService, Learning.Service.UserService>(); 
            #endregion

            #region �û�ģ��
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<UserIOC>();
            //services.AddTransient<BaseUserService>();//ע��users��
            //services.AddTransient<BaseUserInfoService>();//ע��userinfo��
            #endregion

            #endregion
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            //app.UseSession();//����session
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning.Api_Admin v1"));
                app.UseSwaggerUI(c =>
                {

                    c.SwaggerEndpoint("/swagger/Base/swagger.json", "����ģ��");
                    c.SwaggerEndpoint("/swagger/Exam/swagger.json", "����ģ��");
                    c.SwaggerEndpoint("/swagger/Right/swagger.json", "Ȩ��ģ��"); 
                    c.SwaggerEndpoint("/swagger/Organization/swagger.json", "��֯ģ��");
                    c.SwaggerEndpoint("/swagger/Attribute/swagger.json", "����ģ��");
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
