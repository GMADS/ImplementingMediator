using MediatR;

namespace UsingMediator.Application.Commands
{
    public class ChangePersonCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
