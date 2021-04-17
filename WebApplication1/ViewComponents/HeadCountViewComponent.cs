using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IStudentRepository _istudentRepository;

        public HeadCountViewComponent(IStudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }

        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = _istudentRepository.StudentCountByDept(department);
            return View(result);
        }
    }
}
