using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UsingMediator.Domain.Commands;
using UsingMediator.Domain.Models;
using UsingMediator.Domain.NotificationsS;
using UsingMediator.infrastructure.Interfaces;

namespace UsingMediator.Domain.Handlers
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
