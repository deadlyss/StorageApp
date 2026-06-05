using StorageApp.DAL.Models;

namespace StorageApp.DAL.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
