using BlazorAppWebAssemblyServerHybrid.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWebAssemblyServerHybrid.Controller
{
    [ApiController] // APIですという宣言
    [Route("api/form")] // URLの指定
    public class FormController : ControllerBase
    {
        // POSTメソッド
        [HttpPost]
        public IActionResult Save([FromBody] FormData formData)
        {
            // DB or LocalStorageに保存とかする(今はいったんコンソール表示)
            Console.WriteLine($"Text: {formData.Text}");
            Console.WriteLine($"Company: {formData.CompanyName}");
            Console.WriteLine($"Employee: {formData.EmployeeName}");

            // 本来はここでDB保存

            // レスポンス返却
            return Ok(new { message = "保存成功" });
        }
    }
}