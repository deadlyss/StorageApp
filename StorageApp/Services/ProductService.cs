using StorageApp.Models;
using StorageApp.Repositories;

namespace StorageApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<Product?> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task CreateAsync(Product product)
            => _repository.AddAsync(product);

        public Task UpdateAsync(Product product)
            => _repository.UpdateAsync(product);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);
    }
}
