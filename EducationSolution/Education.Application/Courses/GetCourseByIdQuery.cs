using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Courses
{
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDTO> 
        {
            public Guid Id { get; set; }
        }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDTO>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseByIdQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CourseDTO> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var curso = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.Id);

                return _mapper.Map<Course, CourseDTO>(curso);
            }
        }
    }
}