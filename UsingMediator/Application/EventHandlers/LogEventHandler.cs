using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UsingMediator.Application.Notifications;

namespace UsingMediator.Application.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<ChangedPersonNotification>,
                                INotificationHandler<DeletePersonNotification>,
                                INotificationHandler<RegisterPersonNotification>
    {
        public Task Handle(ChangedPersonNotification changedPersonNotification,
                CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CHANGED THE REGISTRATION: " +
                    $" - {changedPersonNotification.Id}" +
                    $" - {changedPersonNotification.Nome}" +
                    $" - {changedPersonNotification.Idade}" +
                    $" - {changedPersonNotification.Sexo}" +
                    $" - {changedPersonNotification.IsEffective}");
            });
        }

        public Task Handle(DeletePersonNotification deletePersonNotification,
                CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"DELETE THE REGISTRATION:" +
                     $" - {deletePersonNotification.Id}" +
                     $" - {deletePersonNotification.IsEffective}");
            });
        }

        public Task Handle(RegisterPersonNotification registerPersonNotification,
                CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"REGISTER RECORD: " +
                    $" - {registerPersonNotification.Id}" +
                    $" - {registerPersonNotification.Idade}" +
                    $" - {registerPersonNotification.Nome}" +
                    $" - {registerPersonNotification.Sexo}");
            });
        }
    }
}
