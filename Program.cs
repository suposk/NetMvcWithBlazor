using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//get IConfiguration instance from builder
IConfiguration configuration = builder.Configuration;
bool IsBlazorEnabled = configuration.GetValue<bool>("IsBlazorEnabled");
if (IsBlazorEnabled)
{
    builder.Services.AddServerSideBlazor();
    builder.Services.AddMudServices();
}

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

app.UseAuthorization();

if (IsBlazorEnabled)
{
    app.MapBlazorHub();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
