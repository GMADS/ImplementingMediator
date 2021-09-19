using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UsingMediator.Application.Commands;
using UsingMediator.Application.Models;
using UsingMediator.Application.Notifications;
using UsingMediator.Interfaces;

namespace UsingMediator.Application.Handlers
{
    public class ChangePersonCommandHandler : IRequestHandler<ChangePersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<People> _repository;

        public ChangePersonCommandHandler(IMediator mediator, IRepository<People> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ChangePersonCommand changePersonCommand,
                CancellationToken cancellationToken)
        {
            var people = new People
            {
                Nome = changePersonCommand.Nome,
                Idade = changePersonCommand.Idade,
                Sexo = changePersonCommand.Sexo
            };

            await _repository.Edit(people);
            await _mediator.Publish(new ChangedPersonNotification
            {
                Nome = people.Nome,
                Idade = people.Idade,
                Sexo = people.Sexo
            });

            return await Task.FromResult("successfully changed person");
        }
    }
}
