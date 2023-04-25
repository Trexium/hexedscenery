using HexedSceneryWebsite.Data;
using HexedSceneryWebsite.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HexedSceneryWebsite.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<HexedSceneryData.Data.HexedSceneryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HexedScenery")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<IRandomHappeningsService, RandomHappeningsService>();
builder.Services.AddTransient<IHiredSwordService, HiredSwordService>();
builder.Services.AddTransient<IWarbandService, WarbandService>();
builder.Services.AddTransient<IGradeService, GradeService>();

var app = builder.Build();

app.UseExceptionHandler("/Error");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
