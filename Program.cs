using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RSVPTake3
{
    public class Program
    { 
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Build().Run();
            }

            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    //.UseIISIntegration()
                    .UseStartup<Startup>();
        }
        /*public class Program
        {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Build().Run();
                //PMTOOL CreateHostBuilder(args).Build().Run();
            }

            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseKestrel();
            //PMTOOL
            /*public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                        .UseStartup<Startup>()
                        .UseIISIntegration();
                        /*.UseKestrel()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()*/
        /*.UseHttpSys(options =>
        {
            options.Authentication.Schemes = 
                AuthenticationSchemes.NTLM | 
                AuthenticationSchemes.Negotiate;
            options.Authentication.AllowAnonymous = false;
        });
    });*/
        //}
    }
