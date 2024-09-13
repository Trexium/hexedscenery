using HexedSceneryWebsite.Api.Auth;
using HexedSceneryWebsite.Components;
using HexedSceneryWebsite.Configuration;
using HexedSceneryWebsite.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;


    // In addition, you can limit the depth
    // options.MaxDepth = 4;
});

//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<HexedSceneryData.Data.HexedSceneryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HexedScenery"), opt => opt.EnableRetryOnFailure()));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(HexedSceneryWebsite.Api.v1.AutoMapperProfile));
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
builder.Services.AddTransient<IApiKeyValidator>(sp =>
{
    var test = builder.Configuration.GetSection("ApiKeys").Get<string[]>();
    var validator = new ApiKeyValidator(builder.Configuration.GetSection("ApiKeys").Get<string[]>());
    return validator;
});
builder.Services.AddScoped<ApiKeyAuthorizationFilter>();


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


// To map api-controllers

app.MapControllers();

app.Run();
