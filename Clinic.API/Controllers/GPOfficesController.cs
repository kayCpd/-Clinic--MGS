using Clinic.API.DTOs.GPOffices;
using Clinic.Application.Features.GPOffices.Commands.CreateGPOffice;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;

using Clinic.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [ApiController]
    [Route("api/gpoffices")]
    public class GPOfficesController : ControllerBase
    {
        private readonly IMediator mediator;

        public GPOfficesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GPOfficeDetailDTO>> Get(Guid id)
        {
            var query = new GetGPOfficeDetailQuery { Id = id };
            var result = await mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<GPOfficesListDTO>>> Get()
        {
            var query = new GetGPOfficesListQuery();
            var result = await mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGPOfficeDTO createGPOfficeDTO)
        {
            var command = new CreateGPOfficeCommand { Name = createGPOfficeDTO.Name };
            await mediator.Send(command);
            return Ok();
        }
    }
}
