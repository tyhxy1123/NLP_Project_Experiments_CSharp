using System.Collections.Generic;

namespace NLP_Praktikum.repository.nodeRepository
{
    public abstract class Repository<T>
    {
        private readonly List<T> _list = new List<T>();
        
        public List<T> FindAll()
        {
            return _list;
        }

        public void Add(T t)
        {
            _list.Add(t);
        }
    }
}