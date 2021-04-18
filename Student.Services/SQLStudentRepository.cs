using Student.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Student.Services
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context ;

        public SQLStudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public student Add(student newStudent)
        {
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;
        }

        public student Delete(int id)
        {
            var studentToDelete = _context.Students.Find(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            return studentToDelete;
        }

        public IEnumerable<student> GetAllStudents()
        {
            return _context.Students;
        }

        public student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<student> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _context.Students;
            }
            return _context.Students.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public IEnumerable<DeptHeadCount> StudentCountByDept(Dept? dept)
        {
            IEnumerable<student> query = _context.Students;

            if (dept.HasValue)
                query = query.Where(x => x.Course == dept.Value);

            return query.GroupBy(x => x.Course)
                .Select(x => new DeptHeadCount()
                {
                    Course = x.Key.Value,
                    Count = x.Count()
                }).ToList();
        }

        public student Update(student updateStudent)
        {
            var student = _context.Students.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateStudent;
        }
    }
}
