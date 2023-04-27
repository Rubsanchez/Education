using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Courses
{
    [TestFixture]
    public class GetCourseQueryNUnitTest
    {
        private GetCourseQuery.GetCourseQueryHandler _handlerAllCourses;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(c => c.CourseId, Guid.Empty)
                .Create());

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid}")
                .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Courses.AddRange(courseRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
                });

            var mapper = mapConfig.CreateMapper();

            _handlerAllCourses = new GetCourseQuery.GetCourseQueryHandler(educationDbContextFake, mapper);
        }


        [Test]
        public async Task GetCourseQueryHandler_GetCourses_ReturnsTrue()
        {
            GetCourseQuery.GetCourseQueryRequest request = new();
            var res = await _handlerAllCourses.Handle(request, new CancellationToken());

            Assert.IsNotNull(res);
        }
    }
}