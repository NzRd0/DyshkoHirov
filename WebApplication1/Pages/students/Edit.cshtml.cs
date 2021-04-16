using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student.Models;
using Student.Services;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Pages.students
{

    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public student Student { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);
            if (Student == null)
                return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost(student student)
        {
            if (Photo != null)
            {
                if (student.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", student.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                student.PhotoPath = ProcessUpLoadedFile();
            }
            Student = _studentRepository.Update(student);
            return RedirectToPage("student");
        
        }

        private string ProcessUpLoadedFile()
        {
            string uniqurFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqurFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqurFileName);


                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqurFileName;
        }
    }
}
