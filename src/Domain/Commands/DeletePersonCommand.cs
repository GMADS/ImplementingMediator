using MediatR;

namespace UsingMediator.Domain.Commands
{
    public class DeletePersonCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
