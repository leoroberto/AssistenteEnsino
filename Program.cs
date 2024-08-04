using AssistenteDeEnsino.Components;
using AssistenteDeEnsino.Components.Player.Data;
using AssistenteDeEnsino.Configurations;
using AssistenteDeEnsino.Data;
using AssistenteDeEnsino.Services.Markdown;
using AssistenteDeEnsino.Services.OpenAI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IGptService, GptService>();
builder.Services.AddScoped<IMarkdownService, MarkdownService>();

builder.Services.Configure<OpenAIOptions>(builder.Configuration.GetSection("OpenAI"));

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

app.UseDbMigrationHelper();

app.Run();