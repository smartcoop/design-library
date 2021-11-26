// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Moq;
using Smart.Design.Console.CommandOptions;
using Smart.Design.Console.Models;
using Smart.Design.Console.UseCases;
using Xunit;

namespace Opportunity.DesignSystem.Console.Test.UseCases
{
    public class ListingUseCaseTests
    {
        public ListingUseCaseTests()
        {
        }

        [Fact]
        public void GenerateUseCase_WithValidArgument_IsResponseValid()
        {
            //Arrange
            Mock<ListingOptions> options = new();
            ListingUseCase useCase = new(options.Object);
            //Act
            var response =useCase.Run();
            //Assert
            Assert.IsType<CommandResponse>(response);
            Assert.NotNull(response);
            Assert.NotEmpty(response.GetResponseMessage());
        }
    }
}
