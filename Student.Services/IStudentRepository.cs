using System;
using System.Collections.Generic;
using System.Text;
using Student.Models;

namespace Student.Services
{
    public interface IStudentRepository
    {
        IEnumerable<student> GetAllStudents();
        student GetStudent(int id);
        student Update(student updateStudent);
    }
}
