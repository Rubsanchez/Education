using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Courses
{
    public class GetCourseQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDTO>> { }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDTO>>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CourseDTO>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Courses.ToListAsync();

                return _mapper.Map<List<Course>, List<CourseDTO>>(cursos);
            }
        }
    }
}