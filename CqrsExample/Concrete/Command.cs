using CqrsExample.Abstract;
using Domain.Abstract;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsExample.Concrete
{
    public class Command<T> : ICommand<T> where T : class
    {
        private readonly ITemplateRepository<T> _repo;

        public Command(ITemplateRepository<T> repo)
        {
            _repo = repo;
        }

        public void Create(T item)
        {
            _repo.Create(item);
        }
        public void Update(T item)
        {
            _repo.Update(item);
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
