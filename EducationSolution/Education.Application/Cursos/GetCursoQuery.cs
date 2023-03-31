using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoQuery
    {
        public class GetCursoQueryRequest : IRequest<List<Curso>> { }

        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<Curso>>
        {
            private readonly EducationDbContext _context;

            public GetCursoQueryHandler(EducationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Curso>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();

                return cursos;
            }
        }
    }
}