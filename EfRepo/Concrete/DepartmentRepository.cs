using Domain.Models;
using EfRepo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepo.Concrete
{
    public class DepartmentRepository : AbstractRepository<Department>
    {
        public override void Create(Department item)
        {
            _db.Departments.Add(item);
            _db.SaveChanges();
        }

        public override void Delete(Guid id)
        {
            var result = _db.Departments.FirstOrDefault(d => d.Id == id);
            if (result != null)
            {
                _db.Departments.Remove(result);
                _db.SaveChanges();
            }

        }
    }
}
