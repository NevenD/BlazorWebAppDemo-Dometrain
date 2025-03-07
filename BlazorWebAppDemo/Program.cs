using BlazorWebAppDemo.Components;
using BlazorWebAppDemo.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//Transient - New instance everytime we ask for one
builder.Services.AddTransient<IMyService, MyService>();


/*  Scoped - New instance per circuit in Blazor Server and one instance for Blazor WebAssembly as long as the app is loaded
builder.Services.AddScoped<IMyService, MyService>();
*/

//  Singleton - One instance shared with all users
//builder.Services.AddSingleton<IMyService, MyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppDemo.Client._Imports).Assembly);

app.Run();
