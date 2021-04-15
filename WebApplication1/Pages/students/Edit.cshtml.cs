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
   
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public EditModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

         public student Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);
            if (Student == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
    }
}
