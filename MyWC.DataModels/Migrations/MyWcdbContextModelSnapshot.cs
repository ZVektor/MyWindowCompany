﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWC.DataModels.Models;

#nullable disable

namespace MyWC.DataModels.Migrations
{
    [DbContext(typeof(MyWcdbContext))]
    partial class MyWcdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWC.DataModels.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("LastName")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id")
                        .HasName("PK__People__3214EC07587720CB");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Кемерово",
                            FirstName = "Денис",
                            LastName = "Хорошевский"
                        },
                        new
                        {
                            Id = 2,
                            City = "Омск",
                            FirstName = "Ольга",
                            LastName = "Корнелюк"
                        },
                        new
                        {
                            Id = 3,
                            City = "Томск",
                            FirstName = "Вадим",
                            LastName = "Сапрыгин"
                        },
                        new
                        {
                            Id = 4,
                            City = "Орск",
                            FirstName = "Александр",
                            LastName = "Великий"
                        },
                        new
                        {
                            Id = 5,
                            City = "Оренбург",
                            FirstName = "Виктория",
                            LastName = "Дайнеко"
                        },
                        new
                        {
                            Id = 6,
                            City = "Москва",
                            FirstName = "Демис",
                            LastName = "Карибидис"
                        },
                        new
                        {
                            Id = 7,
                            City = "Кемерово",
                            FirstName = "Сергей",
                            LastName = "Силиванов"
                        },
                        new
                        {
                            Id = 8,
                            City = "Красноярск",
                            FirstName = "Тимур",
                            LastName = "Спайкин"
                        },
                        new
                        {
                            Id = 9,
                            City = "Новокузнецк",
                            FirstName = "Ксения",
                            LastName = "Ловачева"
                        },
                        new
                        {
                            Id = 10,
                            City = "Прокопьевск",
                            FirstName = "Ольга",
                            LastName = "Реснина"
                        },
                        new
                        {
                            Id = 11,
                            City = "Иркутск",
                            FirstName = "Вячеслав",
                            LastName = "Степной"
                        });
                });

            modelBuilder.Entity("MyWC.DataModels.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PeopleId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK__Phone__3214EC071BBC3410");

                    b.HasIndex("PeopleId");

                    b.ToTable("Phone", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PeopleId = 1,
                            PhoneNumber = "89132996666"
                        },
                        new
                        {
                            Id = 2,
                            PeopleId = 2,
                            PhoneNumber = "89231234567"
                        },
                        new
                        {
                            Id = 3,
                            PeopleId = 3,
                            PhoneNumber = "89230254567"
                        },
                        new
                        {
                            Id = 4,
                            PeopleId = 4,
                            PhoneNumber = "89236204567"
                        },
                        new
                        {
                            Id = 5,
                            PeopleId = 5,
                            PhoneNumber = "89231223567"
                        },
                        new
                        {
                            Id = 6,
                            PeopleId = 6,
                            PhoneNumber = "89231254567"
                        },
                        new
                        {
                            Id = 7,
                            PeopleId = 7,
                            PhoneNumber = "89233814567"
                        },
                        new
                        {
                            Id = 8,
                            PeopleId = 8,
                            PhoneNumber = "89231200567"
                        },
                        new
                        {
                            Id = 9,
                            PeopleId = 9,
                            PhoneNumber = "89231241567"
                        },
                        new
                        {
                            Id = 10,
                            PeopleId = 10,
                            PhoneNumber = "89231226567"
                        },
                        new
                        {
                            Id = 11,
                            PeopleId = 11,
                            PhoneNumber = "89832171511"
                        },
                        new
                        {
                            Id = 12,
                            PeopleId = 1,
                            PhoneNumber = "89832171511"
                        });
                });

            modelBuilder.Entity("MyWC.DataModels.Models.Phone", b =>
                {
                    b.HasOne("MyWC.DataModels.Models.Person", "People")
                        .WithMany("Phones")
                        .HasForeignKey("PeopleId")
                        .HasConstraintName("FK__Phone__PeopleId__267ABA7A");

                    b.Navigation("People");
                });

            modelBuilder.Entity("MyWC.DataModels.Models.Person", b =>
                {
                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
