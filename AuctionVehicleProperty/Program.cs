
using AuctionVehicleProperty.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplicationDbContext(builder.Configuration);
builder.Services.AddAplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddAplicationServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Vehicle Details",
        pattern: "/Vehicle/Details/{id}",
        defaults: new { Controller = "Vehicle", Action = "Details" }
    );
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "error",
    pattern: "/Error",
    defaults: new { controller = "Home", action = "Error" }
);
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

await app.CreateAdminRoleAsync(); 

await app.RunAsync();
