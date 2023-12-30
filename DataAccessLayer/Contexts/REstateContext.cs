using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class REstateContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ABDBZ\\SQLEXPRESS;database=DbREstate;integrated security=true");
        }

        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactsUses { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ServiceHousing> ServiceHousings { get; set; }
        public DbSet<ServiceTerrain> ServiceTerrains { get; set; }
        public DbSet<ServiceInfo> ServiceInfos { get; set; }
        public DbSet<ServiceMap> ServiceMaps { get; set; }
        public DbSet<ServicePhoto> ServicePhotos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<WhatWeDo> WhatWeDos { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ServiceHousing>()
        //        .HasMany(sh => sh.ServicePhotos)
        //        .WithOne(sp => sp.ServiceHousing)
        //        .HasForeignKey(sp => sp.ServiceHousingId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ServiceHousing>()
        //        .HasOne(sh => sh.ServiceMap)
        //        .WithMany(sm => sm.ServiceHousings)
        //        .HasForeignKey(sh => sh.ServiceMapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ServiceHousing>()
        //        .HasOne(sh => sh.ServiceInfo)
        //        .WithMany(si => si.ServiceHousings)
        //        .HasForeignKey(sh => sh.ServiceInfoId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ServiceTerrain>()
        //        .HasMany(st => st.ServicePhotos)
        //        .WithOne(sp => sp.ServiceTerrain)
        //        .HasForeignKey(sp => sp.ServiceTerrainId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ServiceTerrain>()
        //        .HasOne(st => st.ServiceMap)
        //        .WithMany(sm => sm.ServiceTerrains)
        //        .HasForeignKey(st => st.ServiceMapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<ServiceTerrain>()
        //        .HasOne(st => st.ServiceInfo)
        //        .WithMany(si => si.ServiceTerrains)
        //        .HasForeignKey(st => st.ServiceInfoId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
