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
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC071BBC3410");

            entity.ToTable("Phone");

            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.People).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PeopleId)
                .HasConstraintName("FK__Phone__PeopleId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
