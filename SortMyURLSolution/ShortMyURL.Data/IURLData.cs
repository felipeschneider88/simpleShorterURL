using ShortMyURL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortMyURL.Data
{
    public interface IURLData
    {
        IEnumerable<URL> getUrlById(string Id);
    }

    public class InMemoryURLData : IURLData
    {
        readonly List<URL> URLs;

        public InMemoryURLData()
        {
            URLs = new List<URL>()
            {
                new URL {Id = "algo", URLValue = "https://google.com" },
                new URL {Id = "otro", URLValue = "https://youtube.com" }
            };
        }
        public IEnumerable<URL> getUrlById(string Id)
        {
            return from uri in URLs
                   where string.IsNullOrEmpty(Id) || uri.Id.StartsWith(Id)
                   orderby uri.Id
                   select uri;
        }
    }
}
