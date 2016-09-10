using core.examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace core.tests
{
    public class StaticClientConsumerSpecs
    {
        [Fact]
        public void ExampleOfSingleUseStatic()
        {
            // Arrange

            var expectedResult = "Ms Class Act";

            // Act

            var result = HelpersFormatting.FormatName("Class", "Act");

            // Assert

            Assert.Equal(expectedResult, result);
        }
    }
}
