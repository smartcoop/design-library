using Microsoft.Extensions.DependencyInjection;
using Moq;
using Opportunity.DesignSystem.Console.CommandOptions;
using Opportunity.DesignSystem.Console.Models;
using Opportunity.DesignSystem.Console.UseCases;
using Smart.Design.Razor.TagHelpers.Elements;
using Smart.Design.Razor.TagHelpers.Html;
using Xunit;

namespace Opportunity.DesignSystem.Console.Test.UseCases
{
    public class GenerateUseCaseTests
    {

        public GenerateUseCaseTests()
        {
        }

        [Fact]
        public void GenerateUseCase_WithValidArgument_IsResponseValid()
        {
            //Arrange
            var options = new Mock<GenerateOptions> {Object = {DesignElementName = "smart-accordion"}};
            GenerateUseCase useCase = new(options.Object);
            //Act
            var response =useCase.Run();
            //Assert
            Assert.IsType<CommandResponse>(response);
            Assert.NotNull(response);
            Assert.NotEmpty(response.GetResponseMessage());
        }
    }
}


