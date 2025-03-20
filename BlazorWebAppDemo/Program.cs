using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorWebAppDemo.Components;
using BlazorWebAppDemo.Demo;
using BlazorWebAppDemo.Demo.Database.Data.Extensions;
using BlazorWebAppDemo.Demo.StateService;
using BlazorWebAppDemo.Services.Services;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//Session/Local Storage Demo
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddCascadingValue(sp =>
{
    var model = new CascadingModel
    {
        SomeText = "Hello from Cascading Value"
    };

    //creating cascading value source that is not fix becuase we want it to update when the property changes
    var source = new CascadingValueSource<CascadingModel>(model, isFixed: false);
    //we are listening any changes to the property 
    model.PropertyChanged += (sender, args) =>
    {
        source.NotifyChangedAsync();
    };

    return source;
});

//Transient - New instance everytime we ask for one
builder.Services.AddTransient<IMyService, MyService>();

//Database demo
builder.Services.AddTodoService();

// State management 
// if we added scoped then onreload it will be lost, if we use 
builder.Services.AddSingleton<StateService>();


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
