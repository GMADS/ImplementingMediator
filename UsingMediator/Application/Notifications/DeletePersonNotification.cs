using MediatR;

namespace UsingMediator.Application.Notifications
{
    public class DeletePersonNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEffective { get; set; }
    }
}
