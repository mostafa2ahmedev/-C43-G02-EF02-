using System;
using System.Collections.Generic;
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

    }
}
