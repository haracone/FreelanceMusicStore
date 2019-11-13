﻿using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Identity;
using System.Collections.Generic;

namespace TestProject.Models
{
    public class ApplicationUserViewModel
    {
            public ICollection<CustomUserRole> Roles { get; set; }
            public virtual string UserName { get; set; }
            public virtual string Email { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
    }
}