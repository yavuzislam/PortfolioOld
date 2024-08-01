using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Repositories.AboutRepositories;
using Portfolio.Repositories.ContactRepositories;
using Portfolio.Repositories.ExperienceRepositories;
using Portfolio.Repositories.FeatureRepositories;
using Portfolio.Repositories.PortfolioDataRepositories;
using Portfolio.Repositories.ServiceRepositories;
using Portfolio.Repositories.SkillRepositories;
using Portfolio.Repositories.SocialMediaRepositories;
using Portfolio.Repositories.TestimonialRepositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Context>(options =>
{
    var config = builder.Configuration;
    var connectionstring = config.GetConnectionString("database");
    options.UseSqlServer(connectionstring);

});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
builder.Services.AddScoped<IPortfolioDataRepository, PortfolioDataRepository>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
