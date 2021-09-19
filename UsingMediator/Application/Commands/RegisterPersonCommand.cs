using MediatR;

namespace UsingMediator.Application.Commands
{
    public class RegisterPersonCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
