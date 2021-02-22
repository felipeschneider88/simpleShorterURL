using ShortMyURL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyURL.Data
{
    public class InMemoryURLData : IURLData
    {
        readonly Dictionary<string,URL> URLs;

        public InMemoryURLData()
        {
            URLs = new Dictionary<string, URL>();
            URL temp = new URL { Id = "algo", URLValue = "https://google.com" };
            URLs.Add(temp.Id, temp);
            temp = new URL { Id = "otro", URLValue = "https://youtube.com" };
            URLs.Add(temp.Id, temp);
        }
        public async Task<URL> GetUrlById(string Id)
        {
            return URLs.GetValueOrDefault(Id);
        }
    }
}
