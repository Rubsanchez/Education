using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Courses
{
    [TestFixture]
    public class CreateCourseCommandNUnitTest
    {
        private CreateCourseCommand.CreateCourseCommandHandler _handlerCreateCourse;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid}")
                .Options;

            var educationDbContextFake = new EducationDbContext(options);

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            });

            _handlerCreateCourse = new CreateCourseCommand.CreateCourseCommandHandler(educationDbContextFake);
        }


        [Test]
        public async Task CreateCourseHandler_InputCourse_ReturnsNumber()
        {
            CreateCourseCommand.CreateCourseCommandRequest request = new()
            {
                PublishDate = DateTime.Now.AddDays(50),
                Title = "Automatic test book .NET",
                Description = "Learn from zero to create unit test",
                Price = 99
            };

            var res = await _handlerCreateCourse.Handle(request, new CancellationToken());

            Assert.That(res, Is.EqualTo(Unit.Value));
        }
    }
}
