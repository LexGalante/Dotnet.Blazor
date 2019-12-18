using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dotnet.Blazor.Infra.Contracts;
using Dotnet.Blazor.Infra;
using Microsoft.EntityFrameworkCore;
using Dotnet.Blazor.Service.Contracts;
using Dotnet.Blazor.Service;
using AutoMapper;

namespace Dotnet.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //inject razor compiler
            services.AddRazorPages();
            //inject service side blazor
            services.AddServerSideBlazor();
            //inject auto mapper
            services.AddAutoMapper(typeof(Startup));
            //inject ef core in memory
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlazorConnection")));
            //inject singleton service of customers
            services.AddTransient<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
