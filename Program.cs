using AppMvc.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(option => {
    // View/Controller/Action.html
    option.ViewLocationFormats.Add("MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

});
builder.Services.AddSingleton(typeof(ProductService),typeof(ProductService));
// builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

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

app.UseRouting(); // EnpointRouting

app.UseAuthorization(); // xác thực quyền truy cập
app.UseAuthentication(); // xac dinh danh tinh

// URL : {controller}/{action}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();   

app.Run();
