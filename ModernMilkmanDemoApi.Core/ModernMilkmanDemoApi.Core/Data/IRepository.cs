using ModernMilkmanDemoApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Data
{
    public interface IRepository
    {
        Task<T> CreateAsync<T>(T entity) where T : class, IBaseDomain;
        Task<T> UpdateAsync<T>(T entity) where T : class, IBaseDomain;
        Task DeleteAsync<T>(T entity) where T : class, IBaseDomain;
        Task<IList<T>> WhereAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IBaseDomain;
    }
}
