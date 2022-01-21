using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModernMilkmanDemoApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Data
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        public readonly DemoContext _context;

        public Repository(DemoContext context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }

        Task<T> IRepository.CreateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DeleteAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository.UpdateAsync<T>(T entity)
        {
            throw new NotImplementedException();
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
                _logger.LogError(e, $"Exception getting item(s) from repository for type of {nameof(T)}", nameof(WhereAsync));
                return null;
            }
        }
    }
}
