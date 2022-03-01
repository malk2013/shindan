using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Shindan.Web;
using Shindan.Web.Core.Authentication.Infrastructure;
using System.Globalization;
 


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
//CLient Services
builder.Services.AddScoped<ShindanStateProvider>()
                .AddScoped<AuthenticationStateProvider, ShindanStateProvider>()
                .AddTransient<AuthenticationHeaderHandler>();
                //.AddScoped(sp => sp
                //    .GetRequiredService<IHttpClientFactory>()
                //    .CreateClient("ShindanAPI").EnableIntercept(sp))
                //.AddHttpClient("ShindanAPI", client =>
                //{
                //    client.DefaultRequestHeaders.AcceptLanguage.Clear();
                //    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                //    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                //})
                //.AddHttpMessageHandler<AuthenticationHeaderHandler>();
//builder.Services.AddHttpClientInterceptor();


builder.Services.AddLocalization();
await builder.Build().RunAsync();
