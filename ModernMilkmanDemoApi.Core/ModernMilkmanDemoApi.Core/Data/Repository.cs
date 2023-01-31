using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Data
{
    public class Repositry : IRepository
    {
        public readonly DemoContext _context;
        private readonly ILogger<Repositry> _logger;

        public Repositry(DemoContext context, ILogger<Repositry> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T> GetByIdAsync<T>(long id) where T : class, IBaseDomain
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsync<T>(T entity) where T : class, IBaseDomain
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete<T>(T entity) where T : class, IBaseDomain
        {
            _context.Set<T>().Remove(entity);
        }

        public T Update<T>(T entity) where T : class, IBaseDomain
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public async Task<IList<T>> WhereAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IBaseDomain
        {
            try
            {
                var set = _context.Set<T>().Where(predicate);
                return await set.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(
                    e,
                    $"Exception getting item(s) from repository for type of {nameof(T)}",
                    nameof(WhereAsync));
                return null;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception saving in repository", nameof(SaveAsync));
                throw;
            }
        }
    }
}