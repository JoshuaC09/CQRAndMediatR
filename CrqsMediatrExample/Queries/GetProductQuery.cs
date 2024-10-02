using MediatR;

namespace CrqsMediatrExample.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}
