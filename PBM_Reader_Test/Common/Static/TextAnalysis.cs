using FluentAssertions;
using PBM_Reader.Common.Static;
using System.Collections.Generic;
using Xunit;

namespace PBM_Reader_Test.Common.Static
{
    public class TextAnalysis_Test
    {
        [Theory]
        [InlineData("part1|part2|part3", "part1", "part2", "part3")]
        public void SplitString_ReturnsExpectedResult(string input, string output1, string output2, string output3)
        {
            // Arrange

            // Act
            List<string> output = TextAnalysis.SplitString(input, new[] { "|" });

            // Assert
            output[0].Should().Be(output1);
            output[1].Should().Be(output2);
            output[2].Should().Be(output3);
        }
    }
}
