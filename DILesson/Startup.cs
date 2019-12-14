using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DILesson.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DILesson
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
            services.AddTransient<IEntitySaverService, EntitySaverService>(); // на каждый конструктор

            //  services.AddSingleton<IEntitySaverService, EntitySaverService>(); // 1 объект на всех

            // services.AddScoped<IEntitySaverService, EntitySaverService>(); // 1 объект на всех, до того пока он не станет нужным

            services.AddTransient<SmsSenderService>();
            
            services.AddTransient<EmailSenderService>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(options => options.MapRoute("default", "api/{controller}"));

        }
    }
}
