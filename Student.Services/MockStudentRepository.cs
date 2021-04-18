using Student.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Student.Services
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<student>()
            {
                new student ()
                { 
                    Id = 0, Name = "Nazar", Course = Dept.english,
                },
                 new student ()
                {
                    Id = 1, Name = "sonya", Course = Dept.HR ,
                },
                  new student ()
                {
                    Id = 2, Name = "petro", Course = Dept.HR ,
                },
                   new student ()
                {
                    Id = 3, Name = "vasyl", Course = Dept.english ,
                },
                      new student ()
                {
                    Id = 4, Name = "Anna", Course = Dept.english ,
                }
            };
        
        }

        public student Add(student newStudent)
        {
            newStudent.Id = _studentList.Max(x => x.Id) + 1;
            _studentList.Add(newStudent);
            return newStudent;
        }

        public student Delete(int id)
        {
            student studentToDelete = _studentList.FirstOrDefault(x => x.Id == id);

            if (studentToDelete != null)
            {
                _studentList.Remove(studentToDelete);
            }

            return studentToDelete;
        }

        public IEnumerable<student> GetAllStudents()
        {
            return _studentList;
        }

        public student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<student> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _studentList;
            }
            return _studentList.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public IEnumerable<DeptHeadCount> StudentCountByDept(Dept? dept)
        {
            IEnumerable<student> query = _studentList;

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
            student student = _studentList.FirstOrDefault(x => x.Id == updateStudent.Id);
            if (student!= null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.Course = updateStudent.Course;
                student.PhotoPath = updateStudent.PhotoPath;

            }
            return student;
        }
    }
}
