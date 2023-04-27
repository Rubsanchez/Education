using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;

namespace Education.Application.Courses
{
    public class CreateCourseCommand
    {
        public class CreateCourseCommandRequest : IRequest<Unit>
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime PublishDate { get; set; }
            public decimal Price { get; set; }
        }

        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
            }
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, Unit>
        {
            private readonly EducationDbContext _context;

            public CreateCourseCommandHandler(EducationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    PublishDate = request.PublishDate,
                    CreationDate = DateTime.Now,
                    Price = request.Price
                };

                _context.Add(course);

                var res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Course cannot be inserted");
            }
        }
    }

}
