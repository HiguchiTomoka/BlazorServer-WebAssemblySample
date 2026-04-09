using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using BlazorAppWebAssemblyServerHybrid.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 自分の置かれているサーバーを叩くための HttpClient を追加
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

// ローカルストレージを使用可能に
builder.Services.AddBlazoredLocalStorage();

// LocalStorageWrapperを使用可能に
builder.Services.AddScoped<LocalStorageWrapper>();

await builder.Build().RunAsync();