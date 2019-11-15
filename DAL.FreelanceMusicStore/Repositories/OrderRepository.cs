using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Linq;

namespace DAL.FreelanceMusicStore.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private EF6DBContext _context;
        public OrderRepository(EF6DBContext context)
        {
            _context = context;
        }

        public void Create(Order Entity)
        {
            _context.Orders.Add(Entity);
        }

        public void Delete(int Id)
        {
            _context.Orders.Remove(_context.Orders.Find(Id));
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Update(Order Entity)
        {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public Order GetById(int Id)
        {
            return _context.Orders.Find(Id);
        }
    }
}
