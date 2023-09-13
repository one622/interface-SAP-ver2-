using BookListRazor.Model;
using BookListRazor.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.AccessControl;

using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;

using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

using System.Data;
using Npgsql;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using BookListRazor.Entities.MasterDb;
using BookListRazor.Helpers;

namespace BookListRazor
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //  options.UseNpgsql(Configuration.GetConnectionString("connectionString")));
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddControllersWithViews();
            //services.AddRazorPages();
            //services.AddSingleton(Configuration);




            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnectiondb"));
            });
            services.AddScoped<IFarmareaRepository, FarmareaRepository>();
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddTransient<IDataService, DataService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton(Configuration);

            //services.AddTransient<IMasterRepository, MasterRepository>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
