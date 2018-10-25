using Domain.Models;
using EfRepo.Abstract;
using System;
using System.Linq;

namespace EfRepo.Concrete
{
    public class EmployeeRepository : AbstractRepository<Employee>
    {
        public override void Create(Employee item)
        {
            _db.Employees.Add(item);
            _db.SaveChanges();
        }

        public override void Delete(Guid id)
        {
            var result = _db.Employees.FirstOrDefault(d => d.Id == id);
            if (result != null)
            {
                _db.Employees.Remove(result);
                _db.SaveChanges();
            }

        }
    }
}
