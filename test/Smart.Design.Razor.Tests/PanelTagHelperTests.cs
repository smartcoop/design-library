using FluentAssertions;
using Xunit;

namespace Smart.Design.Razor.Tests;

public class PanelTagHelperTests
{
    [Fact]
    public void True()
    {
        var t = true;
        t.Should().BeTrue();
    }
}
