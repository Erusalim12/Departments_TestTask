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
    public class DepartmentRepository : AbstractRepository<Department>
    {
        public override IEnumerable<Department> ItemCollection
        {
            get
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    return db.Query<Department>("SELECT * FROM Departments");
                }
            }
        }

        public override void Create(Department item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                var sqlQuery = "INSERT INTO Departments (Id,Name) VALUES(@Id,@Name);";
                db.Execute(sqlQuery, item);
            }
        }


        public override void Delete(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Departments WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public override Department Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Department>("SELECT * FROM Departments WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public override void Update(Department item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Departments SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
