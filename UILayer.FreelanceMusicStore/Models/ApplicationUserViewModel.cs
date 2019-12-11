using Domain.FreelanceMusicStore.Identity;
using System;
using System.Collections.Generic;

namespace TestProject.Models {
    public class ApplicationUserViewModel {
        public Guid Id { get; set; }
        public ICollection<CustomUserRole> Roles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ClientViewModel Client { get; set; }
        public MusicianViewModel Musician { get; set; }
    }
}