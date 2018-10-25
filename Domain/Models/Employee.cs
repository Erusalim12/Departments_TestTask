using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    [Table("Employees")]
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
            Birthdate = new DateTime(1950, 1, 1);
        }
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]

        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary> 
        [Display(Name = "Отчество")]

        public string LastName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        [Display(Name = "Отдел")]
        public virtual Department Department { get; set; }
        [Display(Name = "Отдел")]
        public Guid? DepartmentId { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        [MaxLength(11)]
        public string Phone { get; set; }
    }
}
