using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DatabaseImplement.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseImplement
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounting> Accounting { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomStaff> RoomStaff { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Hotel;User Id=ILYA;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounting>(entity =>
            {
                entity.ToTable("accounting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Roomid).HasColumnName("roomid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounting)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientid_fkey");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Accounting)
                    .HasForeignKey(d => d.Roomid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roomid_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.Roomnumber).HasColumnName("roomnumber");

                entity.Property(e => e.Sleepingberths).HasColumnName("sleepingberths");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Pasport)
                    .IsRequired()
                    .HasColumnName("pasport")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("numeric(7,2)");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasColumnName("available")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("categoryid_fkey");
            });

            modelBuilder.Entity<RoomStaff>(entity =>
            {
                entity.HasKey(e => new { e.Roomid, e.Staffid })
                    .HasName("room_staff_pkey");

                entity.ToTable("room_staff");

                entity.Property(e => e.Roomid).HasColumnName("roomid");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomStaff)
                    .HasForeignKey(d => d.Roomid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roomid_fkey");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.RoomStaff)
                    .HasForeignKey(d => d.Staffid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staffid_fkey");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Employement)
                    .HasColumnName("employement")
                    .HasColumnType("date");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Postid).HasColumnName("postid");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.Postid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("postid_fkey");
            });

            modelBuilder.HasSequence("accountingid");

            modelBuilder.HasSequence("categoryid");

            modelBuilder.HasSequence("clientid");

            modelBuilder.HasSequence("postid");

            modelBuilder.HasSequence("roomid");

            modelBuilder.HasSequence("roomnumber").StartsAt(1000);

            modelBuilder.HasSequence("staffid");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
