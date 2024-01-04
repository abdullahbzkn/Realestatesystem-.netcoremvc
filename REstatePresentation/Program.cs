using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IServiceMapService, ServiceMapManager>();
builder.Services.AddScoped<IServiceMapDal, EfServiceMapDal>();
builder.Services.AddScoped<IServiceInfoService, ServiceInfoManager>();
builder.Services.AddScoped<IServiceInfoDal, EfServiceInfoDal>();
builder.Services.AddScoped<IServiceHousingService, ServiceHousingManager>();
builder.Services.AddScoped<IServiceHousingDal, EfServiceHousingDal>();
builder.Services.AddScoped<IServiceTerrainService, ServiceTerrainManager>();
builder.Services.AddScoped<IServiceTerrainDal, EfServiceTerrainDal>();
builder.Services.AddScoped<IServicePhotoService, ServicePhotoManager>();
builder.Services.AddScoped<IServicePhotoDal, EfServicePhotoDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<IWhatWeDoService, WhatWeDoManager>();
builder.Services.AddScoped<IWhatWeDoDal, EfWhatWeDoDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDal, EfContactUsDal>();
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();
builder.Services.AddScoped<IEntranceService, EntranceManager>();
builder.Services.AddScoped<IEntranceDal, EfEntranceDal>();
builder.Services.AddScoped<IAboutUsService, AboutUsManager>();
builder.Services.AddScoped<IAboutUsDal, EfAboutUsDal>();
builder.Services.AddScoped<IGalleryService, GalleryManager>();
builder.Services.AddScoped<IGalleryDal, EfGalleryDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IVisitorCounterService, VisitorCounterManager>();
builder.Services.AddScoped<IVisitorCounterDal, EfVisitorCounterDal>();

builder.Services.AddDbContext<REstateContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<REstateContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index/";
    });









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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();