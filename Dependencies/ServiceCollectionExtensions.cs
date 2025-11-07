using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PharmacistsSyndicateReNew.implementation.EntityConfigurations;
using PharmacistsSyndicateReNew.implementation.Helper;
using PharmacistsSyndicateReNew.Models;
using PharmacistsSyndicateReNew.Models.Domain.Identity;

namespace PharmacistsSyndicateReNew.Dependencies
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAliHayderBaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SQLDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("ProjectLocalDBConnection")));
            // 🔗 Connection String

            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

            services.AddControllersWithViews(options =>
           {
               options.Filters.Add(new AddAntiforgeryTokenFilter());
           });
            services.AddTransient<DataSeeder>();
            var emailConfig = configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddIdentity<ApplicationUser, IdentityRole>(
               option =>
           {
               option.SignIn.RequireConfirmedEmail = true;
               option.Password.RequiredLength = 8;
               option.Password.RequiredUniqueChars = 0;
               option.Password.RequireNonAlphanumeric = false;
               option.Password.RequireUppercase = true;
               option.Password.RequireDigit = true;
               option.User.RequireUniqueEmail = true;
           }).AddDefaultTokenProviders().AddEntityFrameworkStores<SQLDbContext>().AddErrorDescriber<AppIdentityErrorDescriber>();


            // 🧱 DbContext
            // services.AddDbContext<AliHayderDbContext>(options =>
            //     options.UseSqlServer(connectionString));

            // 🧩 Repositories & Services
            // services
            //     .AddScoped<IUnitOfWork, UnitOfWork>()
            //     .AddScoped<IAuthRepository, AuthRepository>()
            //     .AddScoped<IExternalLoginRepository, ExternalLoginRepository>()
            //     .AddScoped<IEmailServicesRepository, EmailServicesRepository>()
            //     .AddScoped<IJwtRepository, JwtRepository>();

            return services;
        }
        public class AddAntiforgeryTokenFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Request.Method == "POST")
                {
                    var antiForgery = context.HttpContext.RequestServices.GetService<IAntiforgery>();
                    antiForgery.ValidateRequestAsync(context.HttpContext);
                }
                base.OnActionExecuting(context);
            }
        }
    }
}