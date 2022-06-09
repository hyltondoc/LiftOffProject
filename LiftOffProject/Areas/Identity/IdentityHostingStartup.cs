using System;
using LiftOffProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LiftOffProject.Areas.Identity.IdentityHostingStartup))]
namespace LiftOffProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LiftOffProjectIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LiftOffProjectIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LiftOffProjectIdentityDbContext>();
            });
        }
    }
}