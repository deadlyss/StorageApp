using StorageApp.Models;
using StorageApp.Repositories;

namespace StorageApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Warehouse>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<Warehouse?> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task CreateAsync(Warehouse warehouse)
            => _repository.AddAsync(warehouse);

        public Task UpdateAsync(Warehouse warehouse)
            => _repository.UpdateAsync(warehouse);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);
    }
}
