using PBM_Reader.Common.Static;
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
            Assert.NotNull(output);
            Assert.Contains("PBM_Reader_Test", output);

            powerShellHandling.Close();
        }
    }
}
