using BlazorAppWebAssemblyServerHybrid.Client.Models;
using Blazored.LocalStorage;

namespace BlazorAppWebAssemblyServerHybrid.Client.Services
{

    public class LocalStorageWrapper
    {
        private readonly ILocalStorageService _storage;

        public LocalStorageWrapper(ILocalStorageService storage)
        {
            _storage = storage;
        }

        // 保存（期限付き）
        public async Task SetAsync<T>(string key, T value, TimeSpan? expire = null)
        {
            var item = new StorageItem<T>
            {
                Data = value,
                ExpireAt = DateTime.UtcNow.Add(expire ?? TimeSpan.FromHours(1))
            };

            await _storage.SetItemAsync(key, item);
        }

        // 取得（期限チェック付き）
        public async Task<T?> GetAsync<T>(string key)
        {
            var item = await _storage.GetItemAsync<StorageItem<T>>(key);

            if (item == null)
                return default;

            // 期限切れ
            if (item.ExpireAt < DateTime.UtcNow)
            {
                await _storage.RemoveItemAsync(key);
                return default;
            }

            return item.Data;
        }

        // 削除
        public async Task RemoveAsync(string key)
        {
            await _storage.RemoveItemAsync(key);
        }
    }
}