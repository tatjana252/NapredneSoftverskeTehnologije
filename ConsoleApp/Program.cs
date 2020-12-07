using Departments.Data.UnitOfWork;
using Departments.Data.UnitOfWork.Implementation;
using Departments.Domain;
using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp
{
    class Program
    {
        //da biste kreirali bazu treba da izvrsite sledecu naredbu:
        // Update-Database
        private static DepartmentsContext context = new DepartmentsContext();

        static void Main(string[] args)
        {
            using IUnitOfWork unitOfWork = new UnitOfWork(new DepartmentsContext());
            unitOfWork.Departments.Add(new Department { Name = "UOW" });
            unitOfWork.Commit();
            Add();


            //WhereFunc(d=> d.Name.Contains("Katedra"));
        }

        #region t2

        public static void Add()
        {
            Department departments = new Department() { Name = "Katedra za it" };
            context.Add(departments);
            context.SaveChanges();
        }

        public static void UpdateTracked()
        {
            Department departments = context.Departments.Find(1);
            departments.Name = "Katedra za IT";
            context.SaveChanges();
        }

        public static void UpdateNoTracking()
        {
            Department departments = context.Departments.Find(1);
            departments.Name = "Katedra za IT";
            using (DepartmentsContext newContext = new DepartmentsContext())
            {
                newContext.Departments.Update(departments);
                newContext.SaveChanges();
            }
        }

        public static void AddSubject()
        {
            Subject s = new Subject
            {
                Name = "NST",
                DepartmentId = 9,
                Items = new List<SubjectItem>()
                {
                    new SubjectItem
                    {
                        Name = "T1"
                    },
                    new SubjectItem
                    {
                        Name = "T2"
                    }
                }
            };
            context.Subject.Add(s);
            context.SaveChanges();
        }

        public static void UpdateSubjectTracking()
        {
            Subject s = context.Subject.Include(s => s.Items).Single(s => s.SubjectId == 11);
            s.Items[0].Name = "Izmena 2";
            context.SaveChanges();
        }

        public static void UpdateSubjectNoTracking()
        {
            Subject s = context.Subject.Include(s => s.Items).Single(s => s.SubjectId == 11);
            s.Items[0].Name = "Izmena 2";
            using (DepartmentsContext newContext = new DepartmentsContext())
            {
                //newContext.Update(s);
                newContext.Attach(s);
                newContext.Entry(s.Items[0]).State = EntityState.Modified;
                newContext.SaveChanges();
            }

        }

        public static void AddStudentSubject()
        {
            Student student = context.Students.Find(1);
            student.EnrolledSubjects = new List<StudentSubject> { new StudentSubject { SubjectId = 11 },
                 new StudentSubject { SubjectId = 8 },
            };
            context.SaveChanges();
        }

        public static void FindStudent()
        {
            Student student = context.Students.Include(s => s.EnrolledSubjects).ThenInclude(ss => ss.Subject).Single(s => s.StudentId == 1);
            foreach (StudentSubject ss in student.EnrolledSubjects)
            {
                Console.WriteLine(ss.Subject.Name);
            }

        }

        public static void ProjectionQuery()
        {
            var students = context.Students.Select(s =>
            new
            {
                s.StudentId,
                StudentName = s.Name,
                Subjects = s.EnrolledSubjects.Select(ss => ss.Subject).ToList()
            })
                .ToList();

            foreach (var i in students)
            {
                Console.WriteLine($"Student: {i.StudentName} {i.StudentId}");
                foreach (Subject s in i.Subjects)
                {
                    Console.WriteLine(s.Name);
                }
            }

        }

        private static void ReturnSubjectStats()
        {
            List<SubjectStats> res = context.SubjectStats.ToList();
        }

        private static void ReturnSubjectStatsSqlRaw()
        {
            List<SubjectStats> res = context.SubjectStats.FromSqlRaw(@"select name, SubjectId num from Subject").ToList();
            foreach (SubjectStats s in res)
            {
                Console.WriteLine($"{s.StudentsNum} {s.SubjectName}");
            }
        }

        public static void ReturnList()
        {
            IQueryable<Subject> res = context.Subject.Where(s => s.Name.Contains("napredne"));
            res = res.Take(3);
            var result = res.Select(s => new { s.Name });
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
        #endregion
        private static void WhereFunc(Expression<Func<Department, bool>> predicate)
        {
            IQueryable<Department> res = context.Departments.Where(predicate);

            foreach (Department d in res)
            {
                Console.WriteLine(d.Name);
            }
        }

    }
}
