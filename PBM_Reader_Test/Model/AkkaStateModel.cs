using FluentAssertions;
using PBM_Reader.Model;
using System.Collections.Generic;
using Xunit;

namespace PBM_Reader_Test.Model
{
    public class AkkaStateModel_Test
    {
        [Fact]
        public void IP_Property_Should_Return_Correct_Value()
        {
            // Arrange
            var input = new List<string> { "user@192.168.0.1", "John", "Active", "OK", "1.0" };

            // Act
            var model = new AkkaStateModel(input);

            // Assert
            model.IP.Should().Be("192.168.0.1");
        }
    }
}