﻿using DAL.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Domain.FreelanceMusicStore.Identity;

namespace DAL.FreelanceMusicStore
{
    public class EF6DBContext : IdentityDbContext<ApplicationUser, CustomRole  , Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicInstrument> MusicInstruments { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EF6DBContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }
}