using MediatR;

namespace UsingMediator.Domain.Commands
{
    public class RegisterPersonCommand : IRequest<string>
    {
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
    }
}
