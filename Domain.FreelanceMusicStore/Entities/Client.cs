using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.FreelanceMusicStore.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public Guid Guid { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
