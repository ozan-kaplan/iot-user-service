using IoTUserService.Domain.Entities;

namespace IoTUserService.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, string? sortBy, bool sortAsc, Dictionary<string, string>? filters);
        void Update(T entity);
        Task<int> Count(Dictionary<string, string>? filters);
    }
}
