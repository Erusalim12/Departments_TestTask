using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ITemplateRepository<T> where T : class
    {
        IEnumerable<T> ItemCollection { get; }
        void Update(T item);
        T Get(Guid id);
        void Delete(Guid id);
        void Create(T item);

    }
}
