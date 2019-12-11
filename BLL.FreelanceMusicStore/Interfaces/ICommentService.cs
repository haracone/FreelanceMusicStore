using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface ICommentService {
        Task<ServerRequest> AddComment(CommentDTO commentDTO);
        List<CommentDTO> GetAll();
        Task<ServerRequest> DeleteComment(Guid id);
        CommentDTO GetById(Guid id);
    }
}
