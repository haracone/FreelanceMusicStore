using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore.Identity;

namespace DAL.FreelanceMusicStore.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> Clients { get; }
        IRepository<Musician> Musicians { get; }
        IRepository<MusicInstrument> MusicInstruments { get; }
        IRepository<Order> Orders { get; }
        ApplicationUserManager ApplicationUserManager { get; }
        ApplicationRoleManager ApplicationRoleManager { get; }
        Task SaveAsync();
    }
}
