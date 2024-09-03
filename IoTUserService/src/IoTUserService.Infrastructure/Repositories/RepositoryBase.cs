using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using IoTUserService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, string? sortBy, bool sortAsc, Dictionary<string, string>? filters)
        {

            var entity = _context.Set<T>();

            var query = entity.Where(d => !d.IsDeleted);

            if (filters != null)
                foreach (var filter in filters)
                    query = query.Where($"{filter.Key}.Contains(@0)", filter.Value);


            if (!string.IsNullOrEmpty(sortBy))
                query = sortAsc ? query.OrderBy(sortBy) : query.OrderBy($"{sortBy} descending");

            return await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        }

        public Task<int> Count(Dictionary<string, string>? filters)
        {
            var entity = _context.Set<T>();

            var query = entity.Where(d => !d.IsDeleted);

            if (filters != null)
                foreach (var filter in filters)
                    query = query.Where($"{filter.Key}.Contains(@0)", filter.Value);

            return query.CountAsync();
        }
    }
}
