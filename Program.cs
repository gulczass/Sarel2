using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure services and app setup
ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app, builder.Environment);

app.Run();

// Method to configure services
void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    // Register ArticleService
    services.AddScoped<ArticleService>();

    services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();

    services.AddAuthorization(options =>
    {
        options.FallbackPolicy = options.DefaultPolicy;
    });

    services.AddRazorPages();
}

// Method to configure the HTTP request pipeline
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Corrected Route for Articles without specifying action as default
        endpoints.MapControllerRoute(
            name: "articles",
            pattern: "Articles/{action}/{id?}",
            defaults: new { controller = "Home" });

        // Route for ArticleDetails
        endpoints.MapControllerRoute(
            name: "articleDetails",
            pattern: "Articles/Details/{id?}",
            defaults: new { controller = "Home", action = "Details" });
    });
}
