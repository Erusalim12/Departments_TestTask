using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRepo.Abstract
{
    public abstract class AbstractRepository<T> : ITemplateRepository<T> where T : class
    {
        protected readonly string _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public abstract IEnumerable<T> ItemCollection { get; }

        public abstract void Create(T item);
        public abstract void Delete(Guid id);
        public abstract T Get(Guid id);
        public abstract void Update(T item);

    }
}
