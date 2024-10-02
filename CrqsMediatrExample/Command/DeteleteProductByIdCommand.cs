using MediatR;

namespace CrqsMediatrExample.Command
{
    public class DeteleteProductByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeteleteProductByIdCommand(int id)
        {
            Id = id;
        }
    }
}
