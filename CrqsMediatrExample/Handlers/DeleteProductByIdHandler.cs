using CrqsMediatrExample.Command;
using MediatR;

namespace CrqsMediatrExample.Handlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeteleteProductByIdCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public DeleteProductByIdHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
            
        }
        public async Task<Unit> Handle(DeteleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _fakeDataStore.DeleteProduct(request.Id);

            if (!isSuccess) 
            {
                throw new Exception("Not found");
            }

            return Unit.Value;

        }
    }
}
