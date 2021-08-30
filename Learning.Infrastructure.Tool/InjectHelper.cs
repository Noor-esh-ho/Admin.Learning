using Learning.Infrastructure.Tool.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.Tool
{
   public static class InjectHelper
    {
        public static void AddTransient(this IServiceCollection service,Assembly provides,Assembly injects)
        {
            var prs = provides.GetTypes().Where(d => d.GetCustomAttribute(typeof(ProvideAttribute)) != null).ToList();
            prs.ForEach(d =>
            {
                var ijs = injects.GetTypes().Where(e => d.IsAssignableFrom(e) && e.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();
                ijs.ForEach(f => {
                    service.AddTransient(d,f);
                });
            });
         
        }

        public static void AddSingleton(this IServiceCollection service, Assembly provides, Assembly injects)
        {
            var prs = provides.GetTypes().Where(d => d.GetCustomAttribute(typeof(ProvideAttribute)) != null).ToList();
            prs.ForEach(d =>
            {
                var ijs = injects.GetTypes().Where(e => d.IsAssignableFrom(e) && e.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();
                ijs.ForEach(f => {
                    service.AddTransient(d, f);
                });
            });

        }


        public static void AddScoped(this IServiceCollection service, Assembly provides, Assembly injects)
        {
            var prs = provides.GetTypes().Where(d => d.GetCustomAttribute(typeof(ProvideAttribute)) != null).ToList();
            prs.ForEach(d =>
            {
                var ijs = injects.GetTypes().Where(e => d.IsAssignableFrom(e) && e.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();
                ijs.ForEach(f => {
                    service.AddTransient(d, f);
                });
            });

        }
    }
}
