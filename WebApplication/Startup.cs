using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using WebApplication.Identity;
using WebApplication.Infrastructure;    
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using WebApplication.Core.Domains;
using WebApplication.Core;
using WebApplication.Infrastructure.Services;
using WebApplication.Infrastructure.Repository;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.ViewModels;
using WebApplication.Infrastructure.Interface.Services;
using WebMarkupMin.AspNetCore1;
using WebApplication.Helpers;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Infrastructure.Extensions;

namespace WebApplication
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _env = env;
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });


        }

        public IConfigurationRoot Configuration { get; }

        public IHostingEnvironment _env;
        public MapperConfiguration MapperConfiguration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddMongoDBIdentityStores<ApplicationDbContext, IdentityUser, IdentityRole, string>(options =>
            {
                options.ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"];
            })
           .AddDefaultTokenProviders();

            services.AddSingleton<UserStore<IdentityUser, IdentityRole>>();

            //services.AddSingleton<IMongoDbManager, MongoDbManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IViewModelService, ViewModelService>();
            services.AddSingleton<DashboardViewModel, DashboardViewModel>();
            services.AddSingleton<IStatusTypeRepository, StatusTypeRepository>();
            services.AddSingleton<IFeedItemRepository, FeedItemRepository>();
            services.AddSingleton<IFeedItemService, FeedItemService>();
            services.AddSingleton<IProfileService, ProfileService>();
            services.AddSingleton<SeedDataHelper>();
            services.AddSingleton<IProfileSettingViewModelService, ProfileSettingViewModelService>();
            services.AddSingleton<IRoleStatusTypeMappingRepository, RoleStatusTypeMappingRepository>();


            services.AddSingleton<IPositiveItemRepository, PositiveItemRepository>();
            services.AddSingleton<ITechItemRepository, TechItemRepository>();

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton(sp => MapperConfiguration.CreateMapper());

           
            services.AddWebMarkupMin(
        options =>
        {
            options.AllowMinificationInDevelopmentEnvironment = true;
            options.AllowCompressionInDevelopmentEnvironment = true;
        })
        .AddHtmlMinification(
            options =>
            {
                options.MinificationSettings.RemoveRedundantAttributes = true;
                options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
            })
          .AddHtmlMinification(
            options =>
            {
                options.MinificationSettings.RemoveRedundantAttributes = true;
                options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
            })
        .AddHttpCompression();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SeedDataHelper seed)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddNLog();
            //loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseStatusCodePagesWithReExecute("/errors/{0}");

            }
            //app.AddNLogWeb();
            //env.ConfigureNLog("nlog.config");

            app.UseStaticFiles();
            

            //app.UseCors(builder => {
            //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //});

            app.UseWebMarkupMin();
                        
            app.UseStatusCodePages();

            app.UseCookieAuthentication();

            app.UseIdentity()
               .UseFacebookAuthentication(new FacebookOptions
               {
                   AppId = "1188984081223294",
                   AppSecret = "4bed0b56cb77b0b2f1643384eb8f0266"
               })
                .UseGoogleAuthentication(new GoogleOptions
                {
                    ClientId = "1007746957521-ei30jkh72jq90fec7m3re91dpeaobgl4.apps.googleusercontent.com",
                    ClientSecret = "MEKtgoPZGPYxu9aHqkIeqmqj-"
                })
                .UseTwitterAuthentication(new TwitterOptions
                {
                    ConsumerKey = "tl0zTPXYqQRV969qVbXyCQsb8",
                    ConsumerSecret = "fF4cdlcMxeDrvZJFLRZAj7SDkQt7NYBetewCzbJzRxUUbPCMmO"
                });

            seed.Initialize();

            //app.Use(async (context, next) =>
            //{
            //    await next();

            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/index.html"; // Put your Angular root page here 
            //        await next();
            //    }
            //});
           // app.UseCustomRewriter();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areaRoute",
                   template: "{area:exists}/{controller}/{action}/{id?}",
                   defaults: new { controller = "Home", action = "Index" });
                    
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "feed",
                    template: "feed/{action}/{id?}",
                    defaults: new {area="Feed",  controller = "Feed", action = "Index" });

                routes.MapRoute(
                name: "admin",
                template: "admin/{action}/{id?}",
                defaults: new { area = "Admin", controller = "Dashboard", action = "Index" });


                //routes.MapRoute(
                //     name: "api",
                //     template: "api/{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //     name: "feed",
                //     template: "feed/{controller}/{action}",
                //     defaults: new { controller = "Feed", action = "Index" });

                //routes.MapRoute(
                //     name: "admin",
                //     template: "admin/{controller}/{action}/{id?}",
                //     defaults: new { controller = "Dashboard", action = "Index" });

                //routes.MapRoute(
                //     name: "profile",
                //     template: "profile/{controller}/{action}",
                //     defaults: new { controller = "Profile", action = "Index" });

            });
        }


    }







}