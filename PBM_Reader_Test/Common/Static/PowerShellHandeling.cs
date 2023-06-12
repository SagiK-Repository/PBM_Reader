using FluentAssertions;
using PBM_Reader.Common.Static;
using System.Collections.Generic;
using Xunit;

namespace PBM_Reader_Test.Common.Static
{
    public class PowerShellHandeling_Test
    {
        [Fact]
        public void ExecuteCommand_ReturnsExpectedOutput()
        {
            // Arrange
            string command = "Get-Process";
            PowerShellHandling powerShellHandling = new PowerShellHandling();

            // Act
            string output = powerShellHandling.ExecuteCommand(command);

            // Assert
            output.Should().NotBeNullOrEmpty();
            output.Should().Contain("PBM_Reader_Test");

            powerShellHandling.Close();
        }

        [Fact]
        public void ExecuteCommandLines_ReturnsExpectedOutputLines()
        {
            // Arrange
            string command = "Get-Process";
            PowerShellHandling powerShellHandling = new PowerShellHandling();

            // Act
            List<string> outputLines = powerShellHandling.ExecuteCommandLines(command);

            // Assert
            outputLines.Should().NotBeNullOrEmpty();
            outputLines[0].Should().Be("Windows PowerShell");
            outputLines[1].Should().Be("Copyright (C) Microsoft Corporation. All rights reserved.");
            outputLines[7].Should().Be("Handles");
            outputLines[7].Should().Be("CPU(s)");
            outputLines[7].Should().Be("ProcessName");

            powerShellHandling.Close();
        }
    }
}
