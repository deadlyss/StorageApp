using StorageApp.Models;

namespace StorageApp.Services
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        Task CreateAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
