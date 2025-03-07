using ApplicationLayer.Interactors;
using Core.InputPorts;
using DomainLayer.SeedCore.OutputPorts.Gateways;
using DomainLayer.SeedCore.OutputPorts.Presenters;
using InfrastructureLayer.Database;
using PresentersLayer.Presenters;
using PresentersLayer.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddTransient<ITodoIndexPagePresenter, TodoIndexPagePresenter>();
builder.Services.AddTransient<ITodoReportPresenter, TodoReportPresenter>();

builder.Services.AddDbContext<ITodoContext, TodoContext>();

var app = builder.Build();


using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ITodoContext>();
    context.DatabaseEnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
