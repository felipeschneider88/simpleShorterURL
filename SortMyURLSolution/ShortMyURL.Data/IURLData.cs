using ShortMyURL.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyURL.Data
{
    public interface IURLData
    {
        Task<URL> GetUrlById(string Id);

        Task<URL> InsertUrl(URL url);
    }


}
