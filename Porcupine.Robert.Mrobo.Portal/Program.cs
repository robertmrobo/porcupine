using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Porcupine.Robert.Mrobo.Portal;
using Porcupine.Robert.Mrobo.Portal.IAM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ExampleJsInterop>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5255/api/v1/") });

await builder.Build().RunAsync();