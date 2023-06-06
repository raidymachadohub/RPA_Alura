using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Context;
using RPA.Alura.Infrastructure.Repositories;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Shared.FlowControl.Model;
using Xunit;


namespace RPA.Alura.Tests.Infrastructure.Tests.Repositories.Tests;

public class RoutineRepositoryTests
{
    [Fact]
    public async Task Should_Add_New_Routine_And_Return_Ok()
    {
        using var autoFake = new AutoFake();

        var expectedResult = Result.Ok();

        var routineFake = new Routine(titleSearch: "RPA", active: true);

        // Fake Mock DbSet and Context
        var optionsBuilder = new DbContextOptionsBuilder<RPAContext>();
        var context = new Mock<RPAContext>(optionsBuilder.Options);
        var mockRoutine = new Mock<DbSet<Routine>>();
        context.Setup(r => r.Routine).Returns(mockRoutine.Object);

        //Fake Repository
        var routineRepositoryFake = autoFake.Resolve<IRoutineRepository>();
        A.CallTo(() => routineRepositoryFake.AddRoutineAsync(A<Routine>.Ignored))
            .Returns(expectedResult);

        // Act
        var routineRepository = new RoutineRepository(context.Object);

        var result = await routineRepository.AddRoutineAsync(routineFake);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}