using Domain.FreelanceMusicStore.Entities;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using DAL.FreelanceMusicStore.Interfaces;
namespace DAL.FreelanceMusicStore.Identity
{
    public class UserRepository
    {
        public ApplicationUserManager _manager;

        public UserRepository (ApplicationUserManager manager)
        {
            _manager = manager;
        }

        public void Create(ApplicationUser user)
        {
            _manager.CreateAsync(user);
        }
    }
}
