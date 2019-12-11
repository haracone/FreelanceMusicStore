using DAL.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Entities;
using System.Threading.Tasks;

namespace DAL.FreelanceMusicStore.Interfaces {
    public interface IUnitOfWork {
        IRepository<Client> Clients { get; }
        IRepository<Musician> Musicians { get; }
        IRepository<MusicInstrument> MusicInstruments { get; }
        IRepository<Order> Orders { get; }
        IRepository<Comment> Comments { get; }
        ApplicationUserManager ApplicationUserManager { get; }
        ApplicationRoleManager ApplicationRoleManager { get; }
        Task SaveAsync();
    }
}
