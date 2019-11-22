using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime CommentTime { get; set; }

        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public virtual ApplicationUserViewModel ApplicationUser { get; set; }
        public virtual OrderViewModel Order { get; set; }
    }
}