﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class CustomRoleViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}