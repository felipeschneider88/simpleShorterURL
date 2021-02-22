using Moq;
using ShortMyURL.Core;
using ShortMyURL.Data;
using SortMyURL.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TDDShoryMyURL.Tests
{
    public class URLUnitTest
    {


        public URLUnitTest()
        {
        }
        [Fact]
        public async void URLUnitTest_GetByID()
        {
            //arrange
            InMemoryURLData auxData = new InMemoryURLData();
            var _mockURL = new URLController(auxData);


            //act
            string auxString = "algo";
            URL temp = await _mockURL.Get(auxString);

            //assert
            Assert.Equal("https://google.com", temp.URLValue);

        }
    }
}
