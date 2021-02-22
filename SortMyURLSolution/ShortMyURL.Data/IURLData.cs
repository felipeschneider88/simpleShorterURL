using ShortMyURL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortMyURL.Data
{
    public interface IURLData
    {
        IEnumerable<URL> getUrlById(string Id);
    }


}
