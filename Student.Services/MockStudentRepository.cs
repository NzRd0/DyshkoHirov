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
                    Id = 4, Name = "chmo", Course = Dept.english ,
                }
            };
        
        }
        public IEnumerable<student> GetAllStudents()
        {
            return _studentList;
        }

        public student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(x=>x.Id == id);
        }
    }
}
