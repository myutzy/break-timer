using Blazored.LocalStorage;
using BreakTimer;
using BreakTimer.Services;
using BreakTimer.State;
using Howler.Blazor.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IHowl, Howl>();
builder.Services.AddScoped<IHowlGlobal, HowlGlobal>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<StateContainer>();
builder.Services.AddScoped<SetupService>();
builder.Services.AddScoped<TimeService>();

await builder.Build().RunAsync();
