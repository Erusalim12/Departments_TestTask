using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsExample.Abstract
{
    public interface IQuery<T> where T : class
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
