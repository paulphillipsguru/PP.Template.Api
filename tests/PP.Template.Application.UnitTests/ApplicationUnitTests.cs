using Microsoft.EntityFrameworkCore;
using Moq;
using PP.Template.Application.Interfaces;
using PP.Template.Application.UseCases.Example.Commands;
using PP.Template.Domain.Entities;
using PP.Template.Messages.Example.Commands.Example;

namespace PP.Template.Application.UnitTests;
public class ApplicationUnitTests
{
    [Fact]
    public async Task AddNewExampleHandler_ShouldReturn_ValidEntity()
    {
        //Act
        var mockExampleDbSet = new Mock<DbSet<ExampleEntity>>();
        var applicationDbContextMoq = new Mock<IApplicationDbContext>();
        var request = new AddNewExampleCommand() { Name  = "test" };
        applicationDbContextMoq.Setup(m => m.Example).Returns(mockExampleDbSet.Object);
        var handler = new AddNewExampleHandler(applicationDbContextMoq.Object);

        //Arrange
        var result = await handler.Handle(request, CancellationToken.None);

        //Asset
        mockExampleDbSet.Verify(m=>m.AddAsync(It.IsAny<ExampleEntity>(), CancellationToken.None),Times.Once);
        applicationDbContextMoq.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
