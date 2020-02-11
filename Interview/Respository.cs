using System;
using System.Collections.Generic;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private List<T> objects;

        public Repository()
        {
            objects = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return objects;
        }

        public T Get(I id)
        {
            return objects.Find(Item => Item.Id.Equals(id));
        }

        public void Delete(I id)
        {
            objects.Remove(Get(id));
        }

        public void Save(T item)
        {
            Delete(item.Id);
            objects.Add(item);
        }
    }
}
