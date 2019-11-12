using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Identity;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class ApplicationUserDTO
    {
        public Guid Id { get; set; }
        public virtual ICollection<CustomRole> Roles { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public virtual CustomRole Role { get; set; }
    }
}
