using System.Net;
using _16_Eylul_Kariyet_net.Concrete;
using _16_Eylul_Kariyet_net.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace _16_Eylul_Kariyet_net;

public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<Context>();
            
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;

            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(2);
            options.Lockout.AllowedForNewUsers = true;


            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            




        });

        builder.Services.AddIdentity<Kullanici,IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
        
        
        // Add services to the container.
      
        builder.Services.AddMvc(config =>
        {
            var kural = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        
            config.Filters.Add(new AuthorizeFilter(kural));
        });
        
        //GİRİŞ YAPILMADIĞINDA SAYFAYI YÖNLENDİRECEĞİ SİTE
        
        builder.Services.AddMvc();
         builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(x =>
             {
                 x.LoginPath = "/Login";
                 x.LogoutPath = "/Home";
             });
        
        
        var app = builder.Build();
        
        
        app.UseAuthentication();
        
        
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        //HATA SAYFASI YÖNETİMİ
        app.UseStatusCodePagesWithReExecute("/ErrorPage/Index", "?code={0}");
        
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
              
        app.Run();
    }
}
