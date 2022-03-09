using System.Text;
using System.Threading.Tasks;
using CliWrap;
using Xunit;
using FluentAssertions;

namespace Helloworld.IntegratedTest;

public class HelloworldAppSpec
{
    [Theory]
    [InlineData("Foo", "Hello Foo\r\n")]
    [InlineData("", "Hello \r\n")]
    //[InlineData(null, "Hello \r\n")]
    public async Task Succeed(string input, string expected)
    {
        var stdOutBuffer = new StringBuilder();

#if DEBUG
        var result = await Cli.Wrap(@".\..\..\..\..\..\src\HelloworldApp\bin\Debug\net6.0\HelloworldApp.exe")
#else
        var result = await Cli.Wrap(@".\..\..\..\..\..\src\HelloworldApp\bin\Release\net6.0\HelloworldApp.exe")
#endif
            .WithStandardInputPipe(PipeSource.FromString(input))
            .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
            .ExecuteAsync();

        stdOutBuffer.ToString()
            .Should()
            .EndWith(expected);
    }
}