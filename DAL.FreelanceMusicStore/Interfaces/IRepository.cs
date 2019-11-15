using System;
using System.Linq;

namespace DAL.FreelanceMusicStore.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T Entity);
        IQueryable<T> GetAll();
        T GetById(Guid Id);
        void Delete(Guid Id);
        void Update(T Entity);

    }
}
