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
    public class URLUnitTestInMemory
    {


        public URLUnitTestInMemory()
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

        [Fact]
        public void URLUnitTest_InsertURLDuplicateId()
        {
            //arrange
            InMemoryURLData auxData = new InMemoryURLData();
            var _mockURL = new URLController(auxData);

            //Act

            URL temp = new URL { Id = "algo", URLValue = "https://google.com" };

            //assert
            Assert.Throws<ApplicationException>(() => auxData.Insert(temp.Id, temp));

        }

        [Fact]
        public async Task URLUnitTest_InsertURLAsync()
        {
            //arrange
            InMemoryURLData auxData = new InMemoryURLData();
            var _mockURL = new URLController(auxData);

            //Act
            URL temp = new URL { Id = "nuevo", URLValue = "https://github.com" };
            auxData.Insert(temp.Id, temp);
            temp = await _mockURL.Get(temp.Id);

            //assert
            Assert.Equal(temp.URLValue, temp.URLValue);

        }
    }
}
