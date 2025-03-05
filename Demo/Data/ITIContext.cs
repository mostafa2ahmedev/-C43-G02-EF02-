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


        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Stud_Course> Stud_Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Course_Inst> Course_Inst { get; set; }
        public DbSet<Department> Department { get; set; }



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

            modelBuilder.Entity<Stud_Course>().HasKey(sc => new { sc.Course_ID, sc.Stud_ID });

            modelBuilder.Entity<Course_Inst>().HasKey(ci => new { ci.Course_ID, ci.Inst_ID });

            modelBuilder.Entity<Course>().HasMany(C => C.stud_Courses)
                                          .WithOne()
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>().HasMany(C => C.Course_Inst)
                                          .WithOne()
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>().HasMany(I => I.Course_Inst)
                                          .WithOne()
                                          .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Instructor>().HasOne(I => I.ManagedDept)
                                        .WithOne(D => D.Manager)
                                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>().HasMany(D => D.Instructors)
                                             .WithOne(I => I.Department)
                                             .OnDelete(DeleteBehavior.NoAction);
       

            modelBuilder.Entity<Student>().HasMany(S => S.stud_Courses)
                                          .WithOne()
                                          .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
