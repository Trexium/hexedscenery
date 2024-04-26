using HexedSceneryWebsite.Components;
using HexedSceneryWebsite.Configuration;
using HexedSceneryWebsite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<HexedSceneryData.Data.HexedSceneryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HexedScenery")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IEncounterService, EncounterService>();
builder.Services.AddTransient<IHiredSwordService, HiredSwordService>();
builder.Services.AddTransient<IWarbandService, WarbandService>();
builder.Services.AddTransient<IGradeService, GradeService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserStoredEncountersService, UserStoredEncountersService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IDiceRollService, DiceRollService>();
builder.Services.AddTransient<IResourceService, ResourceService>();
builder.Services.AddTransient<IMonsterService, MonsterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
