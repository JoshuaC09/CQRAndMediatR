using MediatR;

namespace CrqsMediatrExample.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>
    {

    }
}
