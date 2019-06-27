using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.DAL.Repositories
{
    public interface ISqlRepository<T> where T : class
    {
        T GetBy(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        void Remove(T entity);
        void RemoveRange(ICollection<T> entities);
        void Update(T entity);
    }
}
