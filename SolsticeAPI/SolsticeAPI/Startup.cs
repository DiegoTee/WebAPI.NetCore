using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolsticeAPI.BusinessProcess.Implementation;
using SolsticeAPI.BusinessProcess.Interfaces;
using SolsticeAPI.Data;
using SolsticeAPI.Model;
using SolsticeAPI.Services;
using SolsticeAPI.Services.Implementation;
using SolsticeAPI.Services.Interfaces;

namespace SolsticeAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Injected Business Process
            services.AddScoped<IApplicationBusinessProcess, ApplicationBusinessProcess>();
            // Injcted services
            services.AddSingleton<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
