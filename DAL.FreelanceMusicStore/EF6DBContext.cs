using DAL.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Entities;
using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace DAL.FreelanceMusicStore {
    public class EF6DBContext : IdentityDbContext<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim> {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicInstrument> MusicInstruments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public EF6DBContext(string connection) : base(connection) {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public EF6DBContext() : base("DefaultConnection") {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>().HasKey(e => e.Id);
          
            modelBuilder.Entity<Order>().HasRequired(e => e.MusicInstrument);
        /*    modelBuilder.Entity<Order>().HasMany(e => e.Comments).WithRequired(e => e.Order);*/
     //       modelBuilder.Entity<Comment>().HasRequired(e => e.Order).WithMany(e => e.Comments).HasForeignKey(e => e.OrderId);
            modelBuilder.Entity<Comment>().HasRequired(e => e.ApplicationUser).WithMany(e => e.Comments).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Comments).WithRequired(e => e.ApplicationUser);
            modelBuilder.Entity<Client>().HasMany(e => e.Orders).WithRequired(e => e.Client).HasForeignKey(e => e.ClientId);
            modelBuilder.Entity<Client>().HasRequired(e => e.ApplicationUser);
            modelBuilder.Entity<Musician>().HasRequired(e => e.ApplicationUser);
            modelBuilder.Entity<Musician>().HasMany(e => e.MusicInstruments).WithMany(e => e.Musicians).Map(m => m.ToTable("MusicInstrumentMusicians"));
            modelBuilder.Entity<Musician>().HasMany(e => e.Orders).WithOptional(e => e.Musician).HasForeignKey(e => e.MusicianId);

            base.OnModelCreating(modelBuilder);
        }
    }
}