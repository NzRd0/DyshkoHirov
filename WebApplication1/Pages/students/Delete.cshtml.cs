using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student.Models;
using Student.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace WebApplication1.Pages.students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
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
            if (deletedStudent.PhotoPath != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deletedStudent.PhotoPath);
                if (deletedStudent.PhotoPath != "moimage.png")
                    System.IO.File.Delete(filePath);
            }

            if (deletedStudent == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Student");
        }
    }
}
