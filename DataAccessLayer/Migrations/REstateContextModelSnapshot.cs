﻿// <auto-generated />
using System;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(REstateContext))]
    partial class REstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.AboutUs", b =>
                {
                    b.Property<int>("AboutUsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutUsID"), 1L, 1);

                    b.Property<string>("HakkimizdaMetni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutUsID");

                    b.ToTable("AboutUses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Address", b =>
                {
                    b.Property<int>("AdressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdressID"), 1L, 1);

                    b.Property<string>("HaritaLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContactUs", b =>
                {
                    b.Property<int>("ContactUsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactUsID"), 1L, 1);

                    b.Property<string>("IletisimMetni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactUsID");

                    b.ToTable("ContactsUses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Entrance", b =>
                {
                    b.Property<int>("EntranceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntranceID"), 1L, 1);

                    b.Property<string>("Aciklama1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntranceID");

                    b.ToTable("Entrances");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Gallery", b =>
                {
                    b.Property<int>("GalleryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryID"), 1L, 1);

                    b.Property<string>("IlanlarMetni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalleryID");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceHousing", b =>
                {
                    b.Property<int>("ServiceHousingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceHousingID"), 1L, 1);

                    b.Property<int?>("Aidat")
                        .HasColumnType("int");

                    b.Property<int?>("BalkonSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("BanyoSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BinaKatSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("BulunduguKat")
                        .HasColumnType("int");

                    b.Property<bool?>("Devren")
                        .HasColumnType("bit");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<string>("Gorsel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isitma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KiraGetirisi")
                        .HasColumnType("int");

                    b.Property<string>("KonumLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("KrediyeUygun")
                        .HasColumnType("bit");

                    b.Property<string>("KullanimDurumu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OdaSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("SalonSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceMapId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<bool?>("TakasYapilir")
                        .HasColumnType("bit");

                    b.Property<string>("TapuDurumu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TuvaletSayisi")
                        .HasColumnType("int");

                    b.Property<string>("UzunAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YakitTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YapininCephesi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YapininDurumu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YapininSekli")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceHousingID");

                    b.HasIndex("ServiceInfoId");

                    b.HasIndex("ServiceMapId");

                    b.ToTable("ServiceHousings");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceInfo", b =>
                {
                    b.Property<int>("ServiceInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceInfoID"), 1L, 1);

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceInfoID");

                    b.ToTable("ServiceInfos");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceMap", b =>
                {
                    b.Property<int>("ServiceMapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceMapID"), 1L, 1);

                    b.Property<string>("Il")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Koy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mahalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceMapID");

                    b.ToTable("ServiceMaps");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServicePhoto", b =>
                {
                    b.Property<int>("ServicePhotoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicePhotoID"), 1L, 1);

                    b.Property<string>("FotografYolu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceHousingId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceTerrainId")
                        .HasColumnType("int");

                    b.HasKey("ServicePhotoID");

                    b.HasIndex("ServiceHousingId");

                    b.HasIndex("ServiceTerrainId");

                    b.ToTable("ServicePhotos");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceTerrain", b =>
                {
                    b.Property<int>("ServiceTerrainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceTerrainID"), 1L, 1);

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BelediyeAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<string>("Gorsel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IskanDurumu")
                        .HasColumnType("bit");

                    b.Property<int>("IzinVerilenKatAdedi")
                        .HasColumnType("int");

                    b.Property<bool>("KatKarsiligi")
                        .HasColumnType("bit");

                    b.Property<string>("KonumLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KrediyeUygun")
                        .HasColumnType("bit");

                    b.Property<int>("MaksimumBinaYuksekligi")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInfoId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceMapId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TabanInsaaAlani")
                        .HasColumnType("int");

                    b.Property<bool>("TakasYapilir")
                        .HasColumnType("bit");

                    b.Property<int>("TapuAda")
                        .HasColumnType("int");

                    b.Property<string>("TapuDurumu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TapuPafta")
                        .HasColumnType("int");

                    b.Property<int>("TapuParsel")
                        .HasColumnType("int");

                    b.Property<int>("ToplamInsaatAlani")
                        .HasColumnType("int");

                    b.Property<string>("UzunAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VadeVarmi")
                        .HasColumnType("int");

                    b.HasKey("ServiceTerrainID");

                    b.HasIndex("ServiceInfoId");

                    b.HasIndex("ServiceMapId");

                    b.ToTable("ServiceTerrains");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotografYolu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KisiAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EntityLayer.Concrete.WhatWeDo", b =>
                {
                    b.Property<int>("WhatWeDoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WhatWeDoID"), 1L, 1);

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KBaslik1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KBaslik2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KBaslik3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KBaslik4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metin1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metin2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metin3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metin4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NeYapiyoruzMetni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WhatWeDoID");

                    b.ToTable("WhatWeDos");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceHousing", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ServiceInfo", "ServiceInfo")
                        .WithMany("ServiceHousings")
                        .HasForeignKey("ServiceInfoId");

                    b.HasOne("EntityLayer.Concrete.ServiceMap", "ServiceMap")
                        .WithMany("ServiceHousings")
                        .HasForeignKey("ServiceMapId");

                    b.Navigation("ServiceInfo");

                    b.Navigation("ServiceMap");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServicePhoto", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ServiceHousing", "ServiceHousing")
                        .WithMany("ServicePhotos")
                        .HasForeignKey("ServiceHousingId");

                    b.HasOne("EntityLayer.Concrete.ServiceTerrain", "ServiceTerrain")
                        .WithMany("ServicePhotos")
                        .HasForeignKey("ServiceTerrainId");

                    b.Navigation("ServiceHousing");

                    b.Navigation("ServiceTerrain");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceTerrain", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ServiceInfo", "ServiceInfo")
                        .WithMany("ServiceTerrains")
                        .HasForeignKey("ServiceInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.ServiceMap", "ServiceMap")
                        .WithMany("ServiceTerrains")
                        .HasForeignKey("ServiceMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceInfo");

                    b.Navigation("ServiceMap");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceHousing", b =>
                {
                    b.Navigation("ServicePhotos");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceInfo", b =>
                {
                    b.Navigation("ServiceHousings");

                    b.Navigation("ServiceTerrains");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceMap", b =>
                {
                    b.Navigation("ServiceHousings");

                    b.Navigation("ServiceTerrains");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ServiceTerrain", b =>
                {
                    b.Navigation("ServicePhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
