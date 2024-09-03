using IoTUserService.Domain.Repositories;
using IoTUserService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace IoTUserService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IDbContextTransaction? _transaction;
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }

        public UnitOfWork(ApplicationDbContext context, IUserRepository users, IRoleRepository roles)
        {
            _context = context;
            Users = users;
            Roles = roles;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                    await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
