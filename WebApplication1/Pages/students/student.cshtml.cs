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
    public class studentModel : PageModel
        
    {
        private readonly IStudentRepository _db;
        public studentModel(IStudentRepository db)
        {
            _db = db;
        }
        public IEnumerable<student> Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Students = _db.Search(SearchTerm);


        }
    }
}
