using Moq;
using Smart.Design.Console.CommandOptions;
using Smart.Design.Console.Models;
using Smart.Design.Console.UseCases;
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


