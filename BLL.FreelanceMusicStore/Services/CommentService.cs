using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServerRequest> AddComment(CommentDTO commentDTO)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                _unitOfWork.Comments.Create(_mapper.Map<CommentDTO, Comment>(commentDTO));
                await _unitOfWork.SaveAsync();
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occured when you try to write comment";
                return serverRequest;
            }
        }

        public  List<CommentDTO> GetAll()
        {
            var comments = _unitOfWork.Comments.GetAll();
            List<CommentDTO> commentCollection = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                commentCollection.Add(_mapper.Map<Comment, CommentDTO>(comment));
            }

            return commentCollection;
        }

        public CommentDTO GetById(Guid id)
        {
            return _mapper.Map<Comment, CommentDTO>(_unitOfWork.Comments.GetById(id));
        }
        
        public async Task<ServerRequest> DeleteComment(Guid id)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {
                _unitOfWork.Comments.Delete(id);
                await _unitOfWork.SaveAsync();
                return serverRequest;
            }
            catch
            {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error occured when you try to delete comment";
                return serverRequest;
            }
        }
    }
}
