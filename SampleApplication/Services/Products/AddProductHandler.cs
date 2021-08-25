using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleApplication.Models;

namespace SampleApplication.Services.Products
{
    public sealed record AddProductRequest(Product Product) : IRequest<Product>;

    class AddProductHandler : IRequestHandler<AddProductRequest, Product>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;

        public AddProductHandler(InMemoryDataStore inMemoryDataStore)
        {
            _inMemoryDataStore = inMemoryDataStore;
        }

        public async Task<Product> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _inMemoryDataStore.GetAllProducts();

            request.Product.Id = products.LastOrDefault().Id + 1;
            return await _inMemoryDataStore.AddProduct(request.Product);
        }
    }
}
