using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student.Models;
using Student.Services;

namespace WebApplication1.Pages.students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [BindProperty]
        public student student { get; set; }

        public IActionResult OnGet(int id)
        {
            student = _studentRepository.GetStudent(id);

            if (student == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            student deletedStudent = _studentRepository.Delete(student.Id);

            if (deletedStudent == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Student");
        }
    }
}
