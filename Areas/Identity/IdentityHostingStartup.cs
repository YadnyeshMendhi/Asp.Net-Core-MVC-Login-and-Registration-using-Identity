using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication35.Areas.Identity.Data;
using WebApplication35.Data;

[assembly: HostingStartup(typeof(WebApplication35.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication35.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplication35Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplication35ContextConnection")));

                services.AddDefaultIdentity<WebApplication35User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    
                   

                })
                
               
                    .AddEntityFrameworkStores<WebApplication35Context>();
            });
        }
    }
}