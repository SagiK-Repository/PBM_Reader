using FluentAssertions;
using PBM_Reader.Common.Static;
using System.Collections.Generic;
using Xunit;

namespace PBM_Reader_Test.Common.Static
{
    public class TextAnalysis_Test
    {
        [Theory]
        [InlineData(
            "Windows PowerShell" +
            "Copyright(C) Microsoft Corporation.All rights reserved." + "\n" +
            "새로운 크로스 플랫폼 PowerShell 사용 https://aka.ms/pscore6" + "\n" +
            "PS C: \\Users\\juhyu > pbm 127.0.0.1:9100 cluster show" + "\n" +
            "akka.tcp://mls-cluser-system@127.0.0.1:8961 | [mls-db-transfer-data] | up | | 5.0.103" + "\n" +
            "akka.tcp://mls-cluser-system@127.0.0.1:8941 | [mls-node-inference-window-data] | up | | 5.0.103" + "\n" +
            "Count: 6개")]
        public void GetPBMStatusString_ReteunsExpectedString(string input)
        {
            // Arrange

            // Act
            List<string> output = TextAnalysis.GetPBMStatusString(input);

            // Assert
            output.Count.Should().Be(2);
            output[0].Should().StartWith("akka.tcp://");
            output[0].Should().StartWith("akka.tcp://");
        }

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
