using System;

namespace CqrsExample.Abstract
{
    public interface ICommand<T> where T : class
    {
        void Create(T item);
        void Delete(Guid id);
        void Update(T item);
    }
}
