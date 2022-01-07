using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Webapplicaties;
using Project_Webapplicaties.Areas.Identity.Data;
using Project_Webapplicaties.Data;

[assembly: HostingStartup(typeof(Project_Webapplicaties.Areas.Identity.IdentityHostingStartup))]
namespace Project_Webapplicaties.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProjectContextConnection")));

                services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ProjectContext>();
            });
        }
    }
}