using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Linq;

namespace DAL.FreelanceMusicStore.Repositories {
    public class OrderRepository : IRepository<Order> {
        private EF6DBContext _context;
        public OrderRepository(EF6DBContext context) {
            _context = context;
        }

        public void Create(Order Entity) {
            _context.Orders.Add(Entity);
        }

        public void Delete(Guid Id) {
            _context.Orders.Remove(_context.Orders.Find(Id));
        }

        public IQueryable<Order> GetAll() {
            return _context.Orders;
        }

        public void Update(Order Entity) {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public Order GetById(Guid Id) {
            return _context.Orders.Find(Id);
        }
    }
}
