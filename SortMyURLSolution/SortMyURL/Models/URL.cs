using ShortMyURL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortMyURL.Models
{
    public class URL 
    {
        private readonly IURLData _URL;

        public URL()
        {
            _URL = new InMemoryURLData();
        }
    }
}
