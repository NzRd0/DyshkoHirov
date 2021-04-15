using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student.Services;
using Student.Models;

namespace WebApplication1.Pages.students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        public DetailsModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public student Student { get; private set; }

        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);

            if (Student == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
