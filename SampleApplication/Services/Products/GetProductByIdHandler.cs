using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleApplication.Models;

namespace SampleApplication.Services.Products
{
    public sealed record GetProductByIdRequest(int id) : IRequest<Product>;
    class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, Product>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;

        public GetProductByIdHandler(InMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }

        public async Task<Product> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            return await _inMemoryDataStore.GetProductById(request.id);
        }
    }
}
