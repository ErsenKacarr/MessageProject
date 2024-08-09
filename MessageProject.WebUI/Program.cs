
using MessageProject.BusinessLayer.Abstract;
using MessageProject.BusinessLayer.Concrete;
using MessageProject.DataAccessLayer.Abstract;
using MessageProject.DataAccessLayer.Abstravt;
using MessageProject.DataAccessLayer.Context;
using MessageProject.DataAccessLayer.EntityFramework;
using MessageProject.EntityLayer.Concrete;
using MessageProject.WebUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MessageContext>();

builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IDraftDal, EfDraftDal>();
builder.Services.AddScoped<IDraftService, DraftManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MessageContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index";

});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
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
