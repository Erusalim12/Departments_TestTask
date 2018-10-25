using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    [Table("Departments")]
    public class Department
    {
        public Department()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Название отдела")]
        public string Name { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
