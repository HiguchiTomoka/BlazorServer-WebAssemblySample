using BlazorAppWebAssemblyServerHybrid.Client.Models;
using BlazorAppWebAssemblyServerHybrid.Client.Pages;
using BlazorAppWebAssemblyServerHybrid.Components;

var builder = WebApplication.CreateBuilder(args);

// コントローラーのサービスを登録
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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

// コントローラのルーティングを追加
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorAppWebAssemblyServerHybrid.Client._Imports).Assembly);

// Minimal API
app.MapPost("/api/form", async (FormData formData) =>
{
    // とりあえずログ
    Console.WriteLine($"Text: {formData.Text}");
    Console.WriteLine($"Company: {formData.CompanyName}");
    Console.WriteLine($"Employee: {formData.EmployeeName}");

    // 本来はDB保存
    return Results.Ok(new { message = "保存成功" });
});

app.Run();