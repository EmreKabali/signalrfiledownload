using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using signalrfiledownloaddotnetcore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
    });
#endregion

builder.Services.AddRazorPages();


builder.Services.AddHangfire(x => x.UseSqlServerStorage("Server=localhost;Database=googleclosedtest;Persist Security Info=True;User Id=sa;Password=KabaliDatabase123.;TrustServerCertificate=True;"));
builder.Services.AddHangfireServer();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
   {
       endpoints.MapHub<FileDownloadHub>("/FileDownloadHub");
   });


app.MapRazorPages();

app.Run();
