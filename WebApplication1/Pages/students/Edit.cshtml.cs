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
        [BindProperty]
        public student Student { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public  bool Notify { get; set; }

        public String Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                Student = _studentRepository.GetStudent(id.Value);
            else
                Student = new student();
               
            if (Student == null)
                return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Student.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Student.PhotoPath);
                        if (Student.PhotoPath != "moimage.png")
                        System.IO.File.Delete(filePath);
                    }

                    Student.PhotoPath = ProcessUpLoadedFile();
                }

                if (Student.Id > 0)
                {
                    Student = _studentRepository.Update(Student);

                    TempData["SuccessMessage"] = $"Update {Student.Name} successful";
                }
                else 
                {
                    Student = _studentRepository.Add(Student);

                    TempData["SuccessMessage"] = $"Adding {Student.Name} successful";
                }

                return RedirectToPage("student");
            }
         
                return Page();
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Message = "Дякуємо за влкючення сповіщень";
            else
                Message = "Ви вимкнули емейл сповіщення";

            Student = _studentRepository.GetStudent(id);
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
