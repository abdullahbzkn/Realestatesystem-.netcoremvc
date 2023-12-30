using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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

builder.Services.AddDbContext<REstateContext>();
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

app.Run();

