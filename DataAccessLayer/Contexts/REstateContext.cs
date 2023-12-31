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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceInfo>()
                .Property(x => x.EklenmeTarihi)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ServiceInfo>()
                .Property(x => x.GuncellenmeTarihi)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnUpdate();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // ServicePhoto - ServiceHousing ilişkisi
        //    modelBuilder.Entity<ServicePhoto>()
        //        .HasOne(sp => sp.ServiceHousing)
        //        .WithMany(sh => sh.ServicePhotos)
        //        .HasForeignKey(sp => sp.ServiceHousingId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // ServicePhoto - ServiceTerrain ilişkisi
        //    modelBuilder.Entity<ServicePhoto>()
        //        .HasOne(sp => sp.ServiceTerrain)
        //        .WithMany(st => st.ServicePhotos)
        //        .HasForeignKey(sp => sp.ServiceTerrainId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // ServiceMap - ServiceHousing ilişkisi
        //    modelBuilder.Entity<ServiceMap>()
        //        .HasMany(sm => sm.ServiceHousings)
        //        .WithOne(sh => sh.ServiceMap)
        //        .HasForeignKey(sh => sh.ServiceMapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // ServiceMap - ServiceTerrain ilişkisi
        //    modelBuilder.Entity<ServiceMap>()
        //        .HasMany(sm => sm.ServiceTerrains)
        //        .WithOne(st => st.ServiceMap)
        //        .HasForeignKey(st => st.ServiceMapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // ServiceInfo - ServiceHousing ilişkisi
        //    modelBuilder.Entity<ServiceInfo>()
        //        .HasMany(si => si.ServiceHousings)
        //        .WithOne(sh => sh.ServiceInfo)
        //        .HasForeignKey(sh => sh.ServiceInfoId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // ServiceInfo - ServiceTerrain ilişkisi
        //    modelBuilder.Entity<ServiceInfo>()
        //        .HasMany(si => si.ServiceTerrains)
        //        .WithOne(st => st.ServiceInfo)
        //        .HasForeignKey(st => st.ServiceInfoId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
