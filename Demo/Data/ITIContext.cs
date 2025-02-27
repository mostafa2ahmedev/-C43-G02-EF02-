using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    internal class ITIContext: DbContext
    {


        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course_Inst> Course_Insts { get; set; }
        public DbSet<Department> Departments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI;Trusted_Connection=True;Encrypt=False;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>(entity =>
            {
            

                entity.HasKey(d => d.Id); 

                entity.Property(d => d.Id)
                    .ValueGeneratedOnAdd(); 

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)"); 

                entity.Property(d => d.Ins_ID)
                    .IsRequired(); 

                entity.Property(d => d.HiringDate)
                    .IsRequired()
                    .HasColumnType("date");

             
               
            });
            modelBuilder.Entity<Course_Inst>(entity =>
            {

              
                entity.HasKey(ci => new { ci.Inst_ID, ci.Course_ID });

                entity.Property(ci => ci.evaluate)
                      .HasColumnType("varchar(100)") 
                      .IsRequired(false);            
            });

            modelBuilder.Entity<Stud_Course>(entity =>
            {
    
    
                entity.HasKey(sc => new { sc.Stud_ID, sc.Course_ID });

                entity.Property(sc => sc.Grade)
                      .IsRequired(); 
            });

        }
    }
}
