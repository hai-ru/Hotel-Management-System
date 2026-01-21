using System;
using System.Collections.Generic;
using System.Threading;

namespace Hotel_Management_System
{
    /// <summary>
    /// Cache manager untuk menyimpan data yang jarang berubah
    /// Mengurangi request API yang tidak perlu
    /// </summary>
    internal class CacheManager
    {
        private static CacheManager _instance;
        private static readonly object _lock = new object();
        
        private Dictionary<string, CacheItem> _cache;
        private Timer _cleanupTimer;

        private CacheManager()
        {
            _cache = new Dictionary<string, CacheItem>();
            
            // Auto cleanup expired cache setiap 5 menit
            _cleanupTimer = new Timer(CleanupExpiredCache, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
        }

        public static CacheManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CacheManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Simpan data ke cache dengan durasi expire
        /// </summary>
        public void Set(string key, object data, TimeSpan expiration)
        {
            lock (_lock)
            {
                var cacheItem = new CacheItem
                {
                    Data = data,
                    ExpirationTime = DateTime.Now.Add(expiration)
                };
                
                _cache[key] = cacheItem;
            }
        }

        /// <summary>
        /// Ambil data dari cache, return null jika tidak ada atau expired
        /// </summary>
        public T Get<T>(string key) where T : class
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(key))
                {
                    var item = _cache[key];
                    
                    // Cek apakah expired
                    if (DateTime.Now < item.ExpirationTime)
                    {
                        return item.Data as T;
                    }
                    else
                    {
                        // Remove jika expired
                        _cache.Remove(key);
                    }
                }
                
                return null;
            }
        }

        /// <summary>
        /// Cek apakah cache dengan key tertentu masih valid
        /// </summary>
        public bool IsValid(string key)
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(key))
                {
                    return DateTime.Now < _cache[key].ExpirationTime;
                }
                return false;
            }
        }

        /// <summary>
        /// Hapus cache dengan key tertentu
        /// </summary>
        public void Remove(string key)
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(key))
                {
                    _cache.Remove(key);
                }
            }
        }

        /// <summary>
        /// Clear semua cache
        /// </summary>
        public void ClearAll()
        {
            lock (_lock)
            {
                _cache.Clear();
            }
        }

        /// <summary>
        /// Cleanup cache yang sudah expired
        /// </summary>
        private void CleanupExpiredCache(object state)
        {
            lock (_lock)
            {
                var expiredKeys = new List<string>();
                
                foreach (var kvp in _cache)
                {
                    if (DateTime.Now >= kvp.Value.ExpirationTime)
                    {
                        expiredKeys.Add(kvp.Key);
                    }
                }
                
                foreach (var key in expiredKeys)
                {
                    _cache.Remove(key);
                }
            }
        }

        private class CacheItem
        {
            public object Data { get; set; }
            public DateTime ExpirationTime { get; set; }
        }
    }

    /// <summary>
    /// Cache keys untuk consistency
    /// </summary>
    internal static class CacheKeys
    {
        public const string OTA_LIST = "ota_list";
        public const string PAYMENT_METHODS = "payment_methods";
        public const string TIPE_KAMAR = "tipe_kamar";
        public const string TIPE_KEBERSIHAN = "tipe_kebersihan";
        public const string CUSTOMER_LIST = "customer_list";
        public const string BUSINESS_DETAILS = "business_details";
        public const string ROOM_LIST_PREFIX = "room_list_"; // + parameters
        public const string RESERVATION_LIST_PREFIX = "reservation_list_"; // + date
    }
}
