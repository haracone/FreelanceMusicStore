using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public Guid Guid { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
