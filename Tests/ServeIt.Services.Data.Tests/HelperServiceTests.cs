using ServeIt.Services.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
 public class HelperServiceTests
    {
        [Fact]
        public void TestMakeFirstLetterCapitalShouldReturnCorrectAnswer()
        {

            var service = new HelperService();

            var expect = "Happy";
            var result = service.MakeFirstLetterCapital("happy");

            Assert.Equal(expect, result);

        }

    }
}
