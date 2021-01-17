using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.DataAccess;
using Auction.DataAccess.Repositories;
using Auction.Domain.Contracts;
using Auction.Services.Classes;
using Auction.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Auction
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
            ConfigureInjection(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllersWithViews();

            //Database Context
            services.AddDbContext<AuctionDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureInjection(IServiceCollection services)
        {
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            services.AddScoped<IItemRespository, ItemRespository>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
