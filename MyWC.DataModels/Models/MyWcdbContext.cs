using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWC.DataModels.Models;

public partial class MyWcdbContext : DbContext
{
    public MyWcdbContext()
    {
    }

    public MyWcdbContext(DbContextOptions<MyWcdbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyWCDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC07587720CB");

            entity.Property(e => e.City).HasMaxLength(35);
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.LastName).HasMaxLength(35);
            //-----------Start-Начальные данные для заполнения таблиц--------
            entity.HasData(
                new Person { Id = 1, FirstName = "Денис", LastName = "Хорошевский", City = "Кемерово" },
                new Person { Id = 2, FirstName = "Ольга", LastName = "Корнелюк", City = "Омск" },
                new Person { Id = 3, FirstName = "Вадим", LastName = "Сапрыгин", City = "Томск" },
                new Person { Id = 4, FirstName = "Александр", LastName = "Великий", City = "Орск" },
                new Person { Id = 5, FirstName = "Виктория", LastName = "Дайнеко", City = "Оренбург" },
                new Person { Id = 6, FirstName = "Демис", LastName = "Карибидис", City = "Москва" },
                new Person { Id = 7, FirstName = "Сергей", LastName = "Силиванов", City = "Кемерово" },
                new Person { Id = 8, FirstName = "Тимур", LastName = "Спайкин", City = "Красноярск" },
                new Person { Id = 9, FirstName = "Ксения", LastName = "Ловачева", City = "Новокузнецк" },
                new Person { Id = 10, FirstName = "Ольга", LastName = "Реснина", City = "Прокопьевск" },
                new Person { Id = 11, FirstName = "Вячеслав", LastName = "Степной", City = "Иркутск" }
                );
            //-----------End------------------------------------------------
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC071BBC3410");

            entity.ToTable("Phone");

            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.People).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PeopleId)
                .HasConstraintName("FK__Phone__PeopleId__267ABA7A");
            //-----------Start-Начальные данные для заполнения таблиц--------
            entity.HasData(
                new Phone { Id = 1, PhoneNumber = "89132996666", PeopleId = 1 },
                new Phone { Id = 2, PhoneNumber = "89231234567", PeopleId = 2 },
                new Phone { Id = 3, PhoneNumber = "89230254567", PeopleId = 3 },
                new Phone { Id = 4, PhoneNumber = "89236204567", PeopleId = 4 },
                new Phone { Id = 5, PhoneNumber = "89231223567", PeopleId = 5 },
                new Phone { Id = 6, PhoneNumber = "89231254567", PeopleId = 6 },
                new Phone { Id = 7, PhoneNumber = "89233814567", PeopleId = 7 },
                new Phone { Id = 8, PhoneNumber = "89231200567", PeopleId = 8 },
                new Phone { Id = 9, PhoneNumber = "89231241567", PeopleId = 9 },
                new Phone { Id = 10, PhoneNumber = "89231226567", PeopleId = 10 },
                new Phone { Id = 11, PhoneNumber = "89832171511", PeopleId = 11 },
                new Phone { Id = 12, PhoneNumber = "89832171511", PeopleId = 1 }
                );
            //-----------End------------------------------------------------
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
