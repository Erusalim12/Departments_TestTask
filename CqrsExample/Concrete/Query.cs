using CqrsExample.Abstract;
using Domain.Abstract;
using System;
using System.Collections.Generic;

namespace CqrsExample.Concrete
{
    public class Query<T> : IQuery<T> where T : class
    {
        private readonly ITemplateRepository<T> _repo;

        public Query(ITemplateRepository<T> repo)
        {
            _repo = repo;
        }

        public T Get(Guid id)
        {
            return _repo.Get(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _repo.ItemCollection;
        }
    }
}
