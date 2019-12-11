using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Linq;

namespace DAL.FreelanceMusicStore.Repositories {
    public class ClientRepository : IRepository<Client> {
        private EF6DBContext _context;
        public ClientRepository(EF6DBContext context) {
            _context = context;
        }

        public void Create(Client Entity) {
            _context.Clients.Add(Entity);
        }

        public void Delete(Guid Id) {
            _context.Clients.Remove(_context.Clients.Find(Id));
        }

        public IQueryable<Client> GetAll() {
            return _context.Clients;
        }

        public void Update(Client Entity) {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public Client GetById(Guid Id) {
            return _context.Clients.Find(Id);
        }
    }
}
