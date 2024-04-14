
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
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("Home/Error","?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "House Details",
        pattern: "/House/Details/{id}",
        defaults: new { Controller = "House", Action = "Details" }
    );
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

await app.CreateAdminRoleAsync(); 

await app.RunAsync();
