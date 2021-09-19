using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsingMediator.Application.Commands;
using UsingMediator.Application.Models;
using UsingMediator.Interfaces;

namespace UsingMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<People> _repository;

        public PeopleController(IMediator mediator, IRepository<People> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterPersonCommand registerPersonCommand)
        {
            var response = await _mediator.Send(registerPersonCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ChangePersonCommand changePersonCommand)
        {
            var response = await _mediator.Send(changePersonCommand);
            return Ok(changePersonCommand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePersonCommand = new DeletePersonCommand { Id = id };
            var response = await _mediator.Send(deletePersonCommand);
            return Ok(response);
        }

    }
}
