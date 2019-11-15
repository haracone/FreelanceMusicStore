using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Linq;

namespace DAL.FreelanceMusicStore.Repositories
{
    public class MusicianRepository :  IRepository<Musician>
    {
        private EF6DBContext _context;
        public MusicianRepository(EF6DBContext context)
        {
            _context = context;
        }

        public void Create(Musician Entity)
        {
            _context.Musicians.Add(Entity);
        }

        public void Delete(int Id)
        {
            _context.Musicians.Remove(_context.Musicians.Find(Id));
        }

        public IQueryable<Musician> GetAll()
        {
            return _context.Musicians;
        }

        public void Update(Musician Entity)
        {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public Musician GetById(int Id)
        {
            return _context.Musicians.Find(Id);
        }
    }
}
