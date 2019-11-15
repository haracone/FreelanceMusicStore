using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System.Linq;

namespace DAL.FreelanceMusicStore.Repositories
{
    public class MusicInstrumentRepository : IRepository<MusicInstrument>
    {
        private EF6DBContext _context;
        public MusicInstrumentRepository(EF6DBContext context)
        {
            _context = context;
        }

        public void Create(MusicInstrument Entity)
        {
            _context.MusicInstruments.Add(Entity);
        }

        public void Delete(int Id)
        {
            _context.MusicInstruments.Remove(_context.MusicInstruments.Find(Id));
        }

        public IQueryable<MusicInstrument> GetAll()
        {
            return _context.MusicInstruments;
        }

        public void Update(MusicInstrument Entity)
        {
            _context.Entry(GetById(Entity.Id)).CurrentValues.SetValues(Entity);
        }

        public MusicInstrument GetById(int Id)
        {
            return _context.MusicInstruments.Find(Id);
        }
    }
}
