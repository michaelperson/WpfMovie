
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToolBox.MVVM.Interfaces;

namespace ToolBox.Services
{
    public class BaseService<T, TKey> : IBaseService<T, TKey>
        where T : IEntity<TKey>
        where TKey : struct
    {
        private readonly List<T> Elements;

        public BaseService() {
            Elements = new List<T>();
        }

        public virtual void Insert(T Entity) {
            Elements.Add(Entity);
        }

        public virtual void Update(T Entity) { }

        public virtual void Delete(T Entity) {
            Elements.Remove(Entity);
        }
        
        public IQueryable<T> GetAll() {
            return Elements.AsQueryable();
        }

        public IQueryable<T> GetSome(Expression<Func<T, bool>> predicate) {
            return Elements.AsQueryable().Where(predicate);
        }        
 
        public T GetOne(TKey id) {
            return Elements.AsQueryable().SingleOrDefault(Entity => Entity.ID.Equals(id));
        }
    }
}
