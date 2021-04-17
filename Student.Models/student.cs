﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
   public  class student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введіть ім'я")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Неправильний емейл")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Course { get; set; }

    }
}
