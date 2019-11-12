using Domain.FreelanceMusicStore.Entities;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using DAL.FreelanceMusicStore.Interfaces;

namespace DAL.FreelanceMusicStore.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private EF6DBContext _context;
        public ClientRepository(EF6DBContext context)
        {
            _context = context;
        }

        public void Create(Client Entity)
        {
            _context.Clients.Add(Entity);
        }

        public void Delete(int Id)
        {
            _context.Clients.Remove(_context.Clients.Find(Id));
        }

        public IQueryable<Client> GetAll()
        {
            return _context.Clients;
        }

        public void Update(Client Entity)
        {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public Client GetById(int Id)
        {
            return _context.Clients.Find(Id);
        }
    }
}
