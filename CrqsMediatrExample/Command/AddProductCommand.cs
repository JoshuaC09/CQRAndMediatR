using MediatR;

namespace CrqsMediatrExample.Command
{
    public record AddProductCommand(Product Product): IRequest<Product>
    {
    }
}
