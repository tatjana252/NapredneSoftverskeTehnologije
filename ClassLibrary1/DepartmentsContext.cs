using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments.Domain
{
    public class DepartmentsContext : DbContext
    {

        public DepartmentsContext()
        {

        }
        public DepartmentsContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubjectStats> SubjectStats { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasOne(s => s.Department).WithMany();
            modelBuilder.Entity<StudentSubject>().HasKey(ss => new { ss.StudentId, ss.SubjectId });
            modelBuilder.Entity<Subject>(s =>
            {
                s.OwnsMany(s => s.Items).OwnsOne(s => s.Content);
              
            });
            modelBuilder.Entity<StudentSubject>().Ignore(s => s.Prom);

            modelBuilder.Entity<SubjectStats>(ss => {
                ss.HasNoKey();
                ss.ToView("SubjectStats");
                ss.Property(s => s.StudentsNum).HasColumnName("num");
                ss.Property(s => s.SubjectName).HasColumnName("name");
            });
        }
    }
}
