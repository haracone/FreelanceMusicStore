using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Data { get; set; }

        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
