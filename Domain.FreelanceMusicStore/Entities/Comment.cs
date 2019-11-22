using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime CommentTime { get; set; }

        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Order Order { get; set; }
    }
}
