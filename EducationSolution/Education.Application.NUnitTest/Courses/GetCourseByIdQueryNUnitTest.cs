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
    public class GetCourseByIdQueryNUnitTest
    {
        private GetCourseByIdQuery.GetCourseByIdQueryHandler _handlerCourseById;
        private Guid _courseIdTest;

        [SetUp]
        public void Setup()
        {
            _courseIdTest = new Guid("2ce24c4d-df93-4620-ba47-c8065633775f");

            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(c => c.CourseId, _courseIdTest)
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

            _handlerCourseById = new GetCourseByIdQuery.GetCourseByIdQueryHandler(educationDbContextFake, mapper);
        }


        [Test]
        public async Task GetCourseByIdQueryHandler_InputCourseId_ReturnsNotNull()
        {
            GetCourseByIdQuery.GetCourseByIdQueryRequest request = new()
            {
                Id = _courseIdTest
            };

            var res = await _handlerCourseById.Handle(request, new CancellationToken());

            Assert.IsNotNull(res);
        }
    }
}
