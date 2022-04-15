using MediatR;

namespace UsingMediator.Domain.Notifications
{
    public class ChangedPersonNotification : INotification
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public bool IsEffective { get; set; }
    }
}
