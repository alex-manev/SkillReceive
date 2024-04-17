using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.ModelBinders;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationDbContex(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
})
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddApplicationServices();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = new[] 
    {
        CultureInfo.CreateSpecificCulture("en"),
        CultureInfo.CreateSpecificCulture("bg") 
    };
    options.SupportedUICultures = new[]
    {
        CultureInfo.CreateSpecificCulture("en"),
        CultureInfo.CreateSpecificCulture("bg")
    };
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Online Course Details",
        pattern: "/OnlineCourse/Details/{id}/{information}",
        defaults: new {Controller = "OnlineCourse", Action = "Details"}
        );

    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();

await app.RunAsync();
