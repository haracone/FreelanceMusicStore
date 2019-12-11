using DAL.FreelanceMusicStore.Identity;
using System;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.EntityDTO {
    public class ApplicationUserDTO {
        public ApplicationUserDTO() {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public ClientDTO Client { get; set; }
        public MusicianDTO Musician { get; set; }
        public CustomRole Role { get; set; }
        public ICollection<CustomRole> Roles { get; set; }
    }
}
