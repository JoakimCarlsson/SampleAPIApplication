using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SampleApplication.Services.Products
{
    public sealed record GetProductsRequest() : IRequest<IEnumerable<Models.Product>>;
    class GetProductsHandler : IRequestHandler<GetProductsRequest, IEnumerable<Models.Product>>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;

        public GetProductsHandler(InMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }

        public Task<IEnumerable<Models.Product>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            return _inMemoryDataStore.GetAllProducts();
        }
    }
}
