using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VtbCrud;
using VtbCrud.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var CLIENTES_API_URL = builder.Configuration["VtbCrudConfig:CLIENTES_API_URL"];
var SEGMENTOS_API_URL = builder.Configuration["VtbCrudConfig:SEGMENTOS_API_URL"];

builder.Services.AddSingleton(new VtbCrudConfig() { ClientesApiUrl = CLIENTES_API_URL, SegmentosApiUrl = SEGMENTOS_API_URL });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
