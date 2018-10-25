using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepo.Abstract
{
    public abstract class AbstractRepository<T> : ITemplateRepository<T> where T : class
    {

        protected EfDbContext _db = new EfDbContext();
        private DbSet dbSet = new EfDbContext().Set<T>();


        public virtual IEnumerable<T> ItemCollection
        {
            get { return (IEnumerable<T>)dbSet; }
        }

        public abstract void Create(T item);


        public virtual void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }



        public void Delete(T item)
        {
            dbSet.Remove(item);
            _db.SaveChanges();
        }

        public T Get(Guid id)
        {
            return (T)dbSet.Find(id);
        }

        public abstract void Delete(Guid id);

    }

}
