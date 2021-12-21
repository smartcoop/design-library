using Moq;
using Smart.Design.HtmlGenerator.CommandOptions;
using Smart.Design.HtmlGenerator.Models;
using Smart.Design.HtmlGenerator.UseCases;
using Xunit;

namespace Smart.Design.HtmlGenerator.Tests.UseCases;

public class GenerateUseCaseTests
{

    public GenerateUseCaseTests()
    {
    }

    [Fact]
    public void GenerateUseCase_WithValidArgument_IsResponseValid()
    {
        var options = new Mock<GenerateOptions> { Object = { DesignElementName = "smart-accordion" } };
        GenerateUseCase useCase = new(options.Object);

        var response = useCase.Run();

        Assert.IsType<CommandResponse>(response);
        Assert.NotNull(response);
        Assert.NotEmpty(response.GetResponseMessage());
    }
}
