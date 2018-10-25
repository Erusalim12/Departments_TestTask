using Dapper;
using DapperRepo.Abstract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRepo.Concrete
{
    public class EmployeeRepository : AbstractRepository<Employee>
    {
        public override IEnumerable<Employee> ItemCollection
        {
            get
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    return db.Query<Employee>("SELECT * FROM Employees");
                }
            }
        }

        public override void Create(Employee item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Employees (Id,Surname,Name,LastName,Birthdate,DepartmentId,Phone) VALUES(@id,@Surname,@Name,@LastName,@Birthdate,@DepartmentId,@Phone);";
                db.Execute(sqlQuery, item);

            }
        }


        public override void Delete(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Employees WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public override Employee Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Employee>("SELECT * FROM Employees WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public override void Update(Employee item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Employees SET  Surname = @Surname, Name = @Name, Lastname = @Lastname, Birthdate=@Birthdate, DepartmentId=@DepartmentId,Phone=@Phone WHERE Id = @Id";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
