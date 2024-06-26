using EcommerceApp.Config;
using EcommerceApp.Core.Contracts;
using EcommerceApp.Core.Services;
using EcommerceApp.Data;
using EcommerceApp.Extensions;
using EcommerceApp.Infrastructure.Data.Models;
using EcommerceApp.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<User>(options =>
        {
            options.Password.RequireDigit = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();


        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

        builder.Services.AddSignalR();



        var keyBytes = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);

        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = false,
            ValidIssuer = builder.Configuration["JwtConfig:ValidIssuer"],
            ValidAudience = builder.Configuration["JwtConfig:ValidAudience"],
        };

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie(x =>
           {
               x.Cookie.Name = "token";
           })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
                jwt.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["token"];
                        return Task.CompletedTask;
                    }
                };
            });

        builder.Services.AddSingleton(tokenValidationParameters);


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("EcommercePolicy", ecommerceBuilder =>
            {
                ecommerceBuilder.WithOrigins("https://localhost:44440");
                ecommerceBuilder.AllowAnyHeader();
                ecommerceBuilder.AllowAnyMethod();
                ecommerceBuilder.AllowCredentials();
                ecommerceBuilder.SetIsOriginAllowed(x => true);
            });
            options.AddPolicy("free", opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
            });
        });

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IShoesService, ShoesService>();
        builder.Services.AddScoped<IProductSevice, ProductService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<IEmailSender, EmailSender>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<ICouponService, CouponService>();
        builder.Services.AddScoped<IProductStockService, ProductStockService>();
        builder.Services.AddScoped<IDashboardService, DashboardService>();
        builder.Services.AddScoped<IPromotionService, PromotionService>();
        builder.Services.AddScoped<IPictureService, PictureService>();
        builder.Services.AddScoped<IBrandService, BrandService>();
        builder.Services.AddScoped<IUserMessageService, UserMessageService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.MapHub<NotificationsHub>("notifications-hub");

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("EcommercePolicy");
        app.SeedAdministrator("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622");


        //app.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller}/{action=Index}/{id?}");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.MapRazorPages();

        //app.MapFallbackToFile("index.html");

        app.Run();
    }
}