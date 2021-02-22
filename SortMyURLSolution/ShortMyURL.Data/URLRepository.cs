using ShortMyURL.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace ShortMyURL.Data
{
    class URLRepository : IURLData
    {
        private readonly IDistributedCache distributedCache;

        public URLRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }


        #region Serialization Helpers for Redis Cache
        public byte[] ConvertToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                return null;
            }
        }

        // Convert a byte array to an Object
        public Object ConvertToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        #endregion

        public async Task<URL> getUrlById(string Id)
        {
            var url = await distributedCache.GetAsync(Id);
            if (url != null)
                return (URL)this.ConvertToObject(url);
            else
                return null;
        }
    }
}
