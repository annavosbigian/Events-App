using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RSVPTake3.Database;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using RSVPTake3.Services;
using RSVPTake3.Services.Interfaces;

namespace RSVPTake3
{
    public class Startup
    {
        //TODO: Scaffold Command:
        // Scaffold-DbContext 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddRazorPages();
            //services.AddAuthentication(Microsoft.AspNetCore.Server.HttpSys.HttpSysDefaults.AuthenticationScheme);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<EventContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EventConnection")));

            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IDataService, DataService>();

            services.AddControllersWithViews();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.Configure<IISOptions>(options =>
            {
                //test
                options.AutomaticAuthentication = true;
                options.ForwardClientCertificate = true;
            });
            //test

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
                //app.UseExceptionHandler("/Error");
                app.UseDeveloperExceptionPage();


                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                });
                app.UseHsts();
            }

            app.UseCors(options =>
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            var cachePeriod = env.IsDevelopment() ? "600" : "604800";
            /*app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Requires the following import:
                    // using Microsoft.AspNetCore.Http;
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });*/

            app.UseSpaStaticFiles();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }

            });
        }
    }
}


/*TEMP
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
        services.AddControllersWithViews();
        // In production, the Angular files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/dist";
        });


        services.AddAuthentication(IISDefaults.AuthenticationScheme);

        services.AddDbContext<EventContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("EventConnection")));

        services.AddScoped<IEventsService, EventsService>();

        //PMTOOL

        /*services.Configure<IISOptions>(options =>
        {

        });*/

//RSVP
/*TEMP
services.Configure<FormOptions>(o => {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

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
    //RSVP
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    //PMTool
    app.Use(async (context, next) =>
    {
        await next();
        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
        {
            context.Request.Path = "/index.html";
            await next();
        }
    });

    app.UseHsts();
}


app.UseDefaultFiles();

//app.UseHttpsRedirection();

//PHOTOS
//app.UseStaticFiles();

var cachePeriod = env.IsDevelopment() ? "600" : "604800";
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Requires the following import:
        // using Microsoft.AspNetCore.Http;
        ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
    }
});

/*
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});*/

//PMTOOL
/*
var cachePeriod = env.IsDevelopment() ? "600" : "604800";
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Requires the following import:
        // using Microsoft.AspNetCore.Http;
        ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
    }
});*/

//TEMP app.UseSpaStaticFiles();



/*
if (!env.IsDevelopment())
{
    app.UseSpaStaticFiles();
}*/

/*TEMP app.UseRouting();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
   endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller}/{action=Index}/{id?}");
});

app.UseSpa(spa =>
{
   // To learn more about options for serving an Angular SPA from ASP.NET Core,
   // see https://go.microsoft.com/fwlink/?linkid=864501

   spa.Options.SourcePath = "ClientApp";

   if (env.IsDevelopment())
   {
       spa.UseAngularCliServer(npmScript: "start");
   }
});
}
}
}
*/
