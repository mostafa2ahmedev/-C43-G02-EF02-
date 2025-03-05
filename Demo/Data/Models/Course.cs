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
    internal class Course
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Duration { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        [ForeignKey(nameof(Topic))]
        public int Top_ID { get; set; }
        public Topic Topic { get; set; }

        public ICollection<Stud_Course> stud_Courses = new HashSet<Stud_Course>();

        public ICollection<Course_Inst> Course_Inst = new HashSet<Course_Inst>();
    }
}
