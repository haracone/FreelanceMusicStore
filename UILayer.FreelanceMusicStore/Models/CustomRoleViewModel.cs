using System;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models {
    public class CustomRoleViewModel {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}