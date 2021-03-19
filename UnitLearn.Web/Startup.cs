using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Data;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Start => SendMail - ConfigureServices
        public class CustomEmailConfirmationTokenProvider<ApplcationUser> : DataProtectorTokenProvider<ApplcationUser> where ApplcationUser : class
        {
            public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<DataProtectionTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<ApplcationUser>> logger) : base(dataProtectionProvider, options, logger)
            {
            }
        }

        public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
        {
            public EmailConfirmationTokenProviderOptions()
            {
                Name = "EmailDataProtectorTokenProvider";
                TokenLifespan = TimeSpan.FromDays(365);
            }
        }
        //End => SendMail - ConfigureServices
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.SlidingExpiration = true;
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddDistributedMemoryCache();
            services.AddCors();
            services.AddHttpClient();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(356);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".AdventureWorks.Session";
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            var dataProtectionProviderType = typeof(DataProtectorTokenProvider<ApplicationUser>);
            var phoneNumberProviderType = typeof(PhoneNumberTokenProvider<ApplicationUser>);
            var emailTokenProviderType = typeof(EmailTokenProvider<ApplicationUser>);

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 6;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = false;
                config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                        typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
                config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            })
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddTokenProvider(TokenOptions.DefaultProvider, dataProtectionProviderType)
               .AddTokenProvider(TokenOptions.DefaultEmailProvider, emailTokenProviderType)
               .AddTokenProvider(TokenOptions.DefaultPhoneProvider, phoneNumberProviderType);

            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromDays(365));

            //Start => SendMail - ConfigureServices
            services.AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();
            //End => SendMail - ConfigureServices

            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IDashboardService, DashboardService>();
            //services.AddTransient<IZoom, Zoom>();
            //services.AddTransient<IHttpRequestService, HttpRequestService>();
            //services.AddTransient<IDriveService, DriveService>();
            //services.AddTransient<INotificationService, NotificationService>();
            //services.AddTransient<ILinkService, LinkService>();
            //Start => Language - ConfigureServices

            //services.Configure<ZoomOptions>(Configuration.GetSection("Zoom"));
            //services.Configure<FcmSettings>(Configuration.GetSection("FCM"));

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.AspNetCore.Hosting.IHostingEnvironment env2)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //Seed Data Initialize DataBase
            //-- DBInitialize.Initialize(app);
            //  app.UseHangfireDashboard();

            // RecurringJob.AddOrUpdate<IZoom>(
            //     x => x.RefreshingToken(),
            //     Cron.Minutely);

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //RotativaConfiguration.Setup(env2);
        }
    }
}
