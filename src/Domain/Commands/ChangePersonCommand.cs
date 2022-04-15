using MediatR;

namespace UsingMediator.Domain.Commands
{
    public class ChangePersonCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
    }
}
