using MediatR;

namespace UsingMediator.Application.Notifications
{
    public class ChangedPersonNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public bool IsEffective { get; set; }
    }
}
