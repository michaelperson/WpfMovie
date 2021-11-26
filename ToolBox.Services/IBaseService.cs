using System;
using System.Linq;
using System.Linq.Expressions;
using ToolBox.MVVM.Interfaces;

namespace ToolBox.Services
{
    public interface IBaseService<T, TKey>
        where T : IEntity<TKey>
        where TKey : struct
    {
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetSome(Expression<Func<T, bool>> predicate);
        T GetOne(TKey ID);
    }
}
