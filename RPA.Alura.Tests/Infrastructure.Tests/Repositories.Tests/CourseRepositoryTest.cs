using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Context;
using RPA.Alura.Infrastructure.Repositories;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Shared.FlowControl.Model;
using FakeItEasy;
using Xunit;
using Autofac.Extras.FakeItEasy;


namespace RPA.Alura.Tests.Infrastructure.Tests.Repositories.Tests;

public class CourseRepositoryTest
{
    [Fact]
    public async Task Should_Add_New_Course_And_Return_Ok()
    {
        using var autoFake = new AutoFake();

        var expectedResult = Result.Ok();

        var courseFake = new Courses(title: "XUnit C#",
            teacher: "Raidy",
            workLoad: 10,
            description: "Unit Testing using XUnit",
            new Routine(titleSearch: "XUnit", active: true));

        // Fake Mock DbSet and Context
        var optionsBuilder = new DbContextOptionsBuilder<RPAContext>();
        var context = new Mock<RPAContext>(optionsBuilder.Options);
        var mockCourse = new Mock<DbSet<Courses>>();
        context.Setup(r => r.Courses).Returns(mockCourse.Object);

        //Fake Repository
        var courseRepositoryFake = autoFake.Resolve<ICourseRepository>();
        A.CallTo(() => courseRepositoryFake.AddCourseAsync(A<Courses>.Ignored))
            .Returns(expectedResult);

        // Act
        var courseRepository = new CourseRepository(context.Object);

        var result = await courseRepository.AddCourseAsync(courseFake);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}