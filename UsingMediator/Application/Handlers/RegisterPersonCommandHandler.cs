using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UsingMediator.Application.Commands;
using UsingMediator.Application.Models;
using UsingMediator.Application.Notifications;
using UsingMediator.Interfaces;

namespace UsingMediator.Application.Handlers
{
    public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<People> _repository;

        public RegisterPersonCommandHandler(IMediator mediator, IRepository<People> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(RegisterPersonCommand registerPersonCommand,
            CancellationToken cancellationToken)
        {


            var people = new People
            {
                Nome = registerPersonCommand.Nome,
                Idade = registerPersonCommand.Idade,
                Sexo = registerPersonCommand.Sexo
            };

            await _repository.Add(people);

            await _mediator.Publish(new RegisterPersonNotification
            {
                Nome = people.Nome,
                Idade = people.Idade,
                Sexo = people.Sexo
            });

            return await Task.FromResult("successfully changed person");
        }
    }
}
