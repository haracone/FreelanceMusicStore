using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.FreelanceMusicStore.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T Entity);
        IQueryable<T> GetAll();
        T GetById(int Id);
        void Delete(int Id);
        void Update(T Entity);

    }
}
