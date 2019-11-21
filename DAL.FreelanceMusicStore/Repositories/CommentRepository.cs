using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FreelanceMusicStore.Repositories
{
    class CommentRepository : IRepository<Comment>
    {
        private EF6DBContext _context;
        public CommentRepository(EF6DBContext context)
        {
            _context = context;
        }

        public void Create(Comment Entity)
        {
            _context.Comments.Add(Entity);
        }

        public void Delete(Guid Id)
        {
            _context.Comments.Remove(_context.Comments.Find(Id));
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public Comment GetById(Guid Id)
        {
            return _context.Comments.Find(Id);
        }

        public void Update(Comment Entity)
        {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }
    }
}
