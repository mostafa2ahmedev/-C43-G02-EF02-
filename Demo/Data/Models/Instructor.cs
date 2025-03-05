using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string Name { get; set; }
        public int Bonus { get; set; }
        public decimal Salary { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Adress { get; set; }
        public int HourRate { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

      
        [InverseProperty(nameof(Department.Instructors))]
        public Department Department { get; set; } = null!;

        [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDept { get; set; }

        public ICollection<Course_Inst> Course_Inst = new HashSet<Course_Inst>();

     

    }
}
