using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UsingMediator.Application.Commands;
using UsingMediator.Application.Models;
using UsingMediator.Application.Notifications;
using UsingMediator.Interfaces;

namespace UsingMediator.Application.Handlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<People> _repository;

        public async Task<string> Handle(DeletePersonCommand deletePersonCommand,
            CancellationToken cancellationToken)
        {
            await _repository.Delete(deletePersonCommand.Id);
            await _mediator.Publish(new DeletePersonNotification
            {
                Id = deletePersonCommand.Id, IsEffective = true 
            });
            return await Task.FromResult("successfully deleted person");
        }
    }
}
