using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    // By Convention
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string FName { get; set; }
        [Column(TypeName = "varchar(50)")]

        [MaxLength(50)]
        public string LName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(50)]
        public string Address { get; set; }
        public int Age { get; set; }

        [ForeignKey(nameof(Dep_Id))]
        public int Dep_Id { get; set; }

        public Department Department { get; set; } = null!;
        public ICollection<Stud_Course> stud_Courses = new HashSet<Stud_Course>();
    }
}
