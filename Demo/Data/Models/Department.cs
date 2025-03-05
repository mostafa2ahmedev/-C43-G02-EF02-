using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    internal class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Ins_ID { get; set; }
        public DateOnly HiringDate { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        [ForeignKey(nameof(Manager))]
        public int InstructorId { get; set; }


        [InverseProperty(nameof(Instructor.ManagedDept))]
        public Instructor Manager { get; set; } = null!;

        [InverseProperty(nameof(Instructor.Department))]
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
