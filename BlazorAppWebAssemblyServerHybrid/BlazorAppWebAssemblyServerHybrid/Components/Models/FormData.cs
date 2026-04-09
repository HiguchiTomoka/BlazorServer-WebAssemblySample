namespace BlazorAppWebAssemblyServerHybrid.Components.Models
{
    /// <summary>
    ///   フォーム入力値データ
    /// </summary>
    public class FormData
    {
        // 入力欄のテキスト内容
        public string Text { get; set; } = "";
        // 会社名
        public string CompanyName { get; set; } = "";
        // 社員名
        public string EmployeeName { get; set; } = "";
    }
}
