using StorageApp.BLL.Interfaces;
using StorageApp.DAL.Interfaces;
using StorageApp.DAL.Models;

namespace StorageApp.BLL.Services
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
