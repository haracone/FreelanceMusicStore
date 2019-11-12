using DAL.FreelanceMusicStore.Repositories;
using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;

namespace DAL.FreelanceMusicStore
{
    public class UnitOfWork : IUnitOfWork
    {
        private EF6DBContext _context;
        private IRepository<Client> _clientRepository { get; set; }
        private IRepository<Musician> _musicianRepository { get; set; }
        private IRepository<MusicInstrument> _musicInstrumentRepository { get; set; }
        private IRepository<Order> _orderRepository { get; set; }
        private UserRepository _userRepository { get; set; }
        private RoleRepository _roleRepository { get; set; }
        private ApplicationUserManager _applicationUserManager { get; set; }
        private ApplicationRoleManager _applicationRoleManager { get; set; }

        public UnitOfWork()
        {
            _context = new EF6DBContext();
            _applicationUserManager = new ApplicationUserManager(new CustomUserStore(_context));
            _applicationRoleManager = new ApplicationRoleManager(new CustomRoleStore(_context));
            _userRepository = new UserRepository(_applicationUserManager);
            _roleRepository = new RoleRepository(_applicationRoleManager);
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public IRepository<Client> Clients { get { return _clientRepository; } }
        public IRepository<Musician> Musicians { get { return _musicianRepository; } }
        public IRepository<MusicInstrument> MusicInstruments { get { return _musicInstrumentRepository; }}
        public IRepository<Order> Orders { get { return _orderRepository; } }
        public ApplicationUserManager ApplicationUserManager { get { return _applicationUserManager; } }
        public ApplicationRoleManager ApplicationRoleManager { get { return _applicationRoleManager; } }

        public UserRepository UserRepository { get { return _userRepository; } }
        public RoleRepository RoleRepository { get { return _roleRepository; } }
    }
}
