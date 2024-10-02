using CrqsMediatrExample.Command;
using MediatR;

namespace CrqsMediatrExample.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public UpdateProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore; 
        }
        public Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var updatedProduct = _fakeDataStore.UpdateProduct(new Product()
            { Id= request.Id,
              Name=request.Name});

            return updatedProduct;
        }
    }
}
