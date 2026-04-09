namespace BlazorAppWebAssemblyServerHybrid.Client.Models
{
    /// <summary>
    ///   LocalStorage登録用データ
    /// </summary>
    public class StorageItem<T>
    {
        public T Data { get; set; } = default!;
        public DateTime ExpireAt { get; set; }
    }
}
