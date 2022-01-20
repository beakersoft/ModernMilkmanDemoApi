using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Data
{
    public class Repository : IRepository
    {
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

        Task<IList<T>> IRepository.WhereAsync<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
