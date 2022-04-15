using MediatR;

namespace UsingMediator.Domain.NotificationsS
{
    public class DeletePersonNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEffective { get; set; }
    }
}
