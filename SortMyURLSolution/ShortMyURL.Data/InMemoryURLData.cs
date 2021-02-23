using ShortMyURL.Core;
using System;
using System.Collections.Generic;
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
        public URL Find(string id)
        {
            URL result = new URL();
            result = URLs.GetValueOrDefault(id);
            return result;
        }

        public void Insert(string id, URL temp)
        {
            URL aux = Find(id);
            if (aux == null)
                URLs.Add(id, temp);
            else
            {
                string error = string.Format("Allread a URL with that ID");
                throw new ApplicationException(error);
            }
        }

        public async Task<URL> InsertUrl(URL url)
        {
            await Insert(url.Id, url);
        }
    }
}
