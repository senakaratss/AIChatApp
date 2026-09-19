using AIChatApp.Application.Features.Messages.Commands;
using AIChatApp.Application.Interfaces;
using AIChatApp.Persistence.Context;
using AIChatApp.Persistence.Identity;
using AIChatApp.Persistence.Repositories;
using AIChatApp.Persistence.Services;
using AIChatApp.WebUI.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AIChatContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"))
);
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AIChatContext>().AddDefaultTokenProviders();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SendMessageCommand).Assembly));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
});
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IAiService, AiService>();
builder.Services.AddScoped<IVoiceService, ElevenLabsVoiceService>();
builder.Services.AddHttpClient();

builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
