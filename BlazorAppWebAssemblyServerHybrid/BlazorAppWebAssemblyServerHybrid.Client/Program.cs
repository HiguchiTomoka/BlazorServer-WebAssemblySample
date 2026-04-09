using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 自分の置かれているサーバーを叩くための HttpClient を追加
builder.Services.AddSingleton(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// ローカルストレージを使用可能に
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();