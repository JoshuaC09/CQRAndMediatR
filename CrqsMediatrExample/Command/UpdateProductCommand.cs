using MediatR;

namespace CrqsMediatrExample.Command
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateProductCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
