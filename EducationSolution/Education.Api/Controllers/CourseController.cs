using Education.Application.Courses;
using Education.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> Get()
        {
            return await _mediator.Send(new GetCourseQuery.GetCourseQueryRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCourseCommand.CreateCourseCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
