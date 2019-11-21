using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public string Data { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
    }
}
