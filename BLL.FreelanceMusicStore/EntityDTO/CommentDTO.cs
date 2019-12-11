using System;

namespace BLL.FreelanceMusicStore.EntityDTO {
    public class CommentDTO {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime CommentTime { get; set; }

        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public virtual ApplicationUserDTO ApplicationUser { get; set; }
        public virtual OrderDTO Order { get; set; }
    }
}
