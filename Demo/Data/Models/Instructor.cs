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
        public int Bonus    { get; set; }
        public decimal Salary { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Adress { get; set; }
        public int HourRate { get; set; }
        public int Dept_ID { get; set; }
    }
}
