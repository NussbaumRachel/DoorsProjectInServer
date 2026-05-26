using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class DbManager : DbContext
{
    public DbManager()
    {
    }

    public DbManager(DbContextOptions<DbManager> options)
        : base(options)
    {
    }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Door> Doors { get; set; }

    public virtual DbSet<DoorFrame> DoorFrames { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\תיקייה כללית חדש\\שנה א תשפה\\תלמידות\\#PROJECTS\\רחלי קמינר ורחל נוסבוים.mdf';Integrated Security=True;Connect Timeout=30;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07D6FD1E0B");

            entity.Property(e => e.Key).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Value).UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0782E2575A");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Cn)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CN");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Contact_person_name");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Contact_person_phone");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Employee).WithMany(p => p.Customers)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Customers_ToTable");
        });

        modelBuilder.Entity<Door>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doors__3214EC075E959973");

            entity.Property(e => e.Color).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ExternalLayoutLength).HasColumnName("External layout length");
            entity.Property(e => e.ExternalLayoutWidth).HasColumnName("External layout width");
            entity.Property(e => e.Finishing).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ImageUrl)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImageURL");
            entity.Property(e => e.InternalLayoutLength).HasColumnName("Internal layout length");
            entity.Property(e => e.InternalLayoutWidth).HasColumnName("Internal layout width");
            entity.Property(e => e.Leaf).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Opening)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Perforation)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PerforationTypeForShoeing)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Perforation_type_for_shoeing");
            entity.Property(e => e.ShoeingA)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ShoeingB)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ShoeingC)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Skylight).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusArchive).HasDefaultValue(false);
            entity.Property(e => e.TextFileForTheMachine)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Text file for the machine");
            entity.Property(e => e.Type).UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<DoorFrame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoorFram__3214EC07E5F5871A");

            entity.ToTable("DoorFrame");

            entity.HasIndex(e => e.Id, "UQ__DoorFram__3214EC0638DC4EED").IsUnique();

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Desc).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FramesHeightWithShutter).HasColumnName("Frames height with shutter");
            entity.Property(e => e.ImageUrl)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImageURL");
            entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Opening)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Perforation)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PerforationTypeForShoeing)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Perforation_type_for_shoeing");
            entity.Property(e => e.Profile).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.StatusArchive).HasDefaultValue(false);
            entity.Property(e => e.TextFileForTheMachine)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Text file for the machine");
            entity.Property(e => e.WallFrameThickness).HasColumnName("Wall_frame_thickness");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07D25989EF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone1)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone2)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0741688843");

            entity.Property(e => e.ApartmentNum).HasColumnName("Apartment_num");
            entity.Property(e => e.BuildingNum).HasColumnName("Building_num");
            entity.Property(e => e.CustId).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CustName).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DeliveryDate).HasColumnName("Delivery_date");
            entity.Property(e => e.EmployeeId).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Floor).HasColumnName("Floor ");
            entity.Property(e => e.Notes).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.Plot)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Status).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdateDate).HasColumnName("Update_date");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07D51337C0");

            entity.Property(e => e.OrderItemDate).HasColumnName("OrderItem_Date");
            entity.Property(e => e.Status).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__18EBB532");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
