using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApartmentManagement.Models
{
    public partial class Residences_V3Context : DbContext
    {
        public Residences_V3Context()
        {
        }

        public Residences_V3Context(DbContextOptions<Residences_V3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<ComplaintType> ComplaintTypes { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitComplaint> UnitComplaints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-S4BINOV;Initial Catalog=Residences_V3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminCode)
                    .HasName("PK__Admins__E7DC45887B5E38B4");

                entity.Property(e => e.AdminCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("admin_Code");

                entity.Property(e => e.Password)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.ComplaintId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("complaintID");

                entity.Property(e => e.ComplaintDate)
                    .HasColumnType("date")
                    .HasColumnName("complaintDate");

                entity.Property(e => e.ComplaintDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("complaintDescription");

                entity.Property(e => e.ComplaintTypeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("complaintTypeID");

                entity.Property(e => e.LinkedUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("linkedUnit");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.ComplaintType)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.ComplaintTypeId)
                    .HasConstraintName("FK__Complaint__compl__29572725");
            });

            modelBuilder.Entity<ComplaintType>(entity =>
            {
                entity.ToTable("ComplaintType");

                entity.Property(e => e.ComplaintTypeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("complaintTypeID");

                entity.Property(e => e.TypeDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.HasKey(e => e.ResId)
                    .HasName("PK__Resident__27427A5B89C43FE6");

                entity.ToTable("Resident");

                entity.HasIndex(e => e.EmailAddress, "Username")
                    .IsUnique();

                entity.Property(e => e.ResId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("resID");

                entity.Property(e => e.CellNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cellNumber");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.YearMovedIn)
                    .HasColumnType("date")
                    .HasColumnName("yearMovedIn");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("unitID");

                entity.Property(e => e.ResId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("resID");

                entity.Property(e => e.SquareMeters)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("squareMeters");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.ResId)
                    .HasConstraintName("FK__Unit__resID__2C3393D0");
            });

            modelBuilder.Entity<UnitComplaint>(entity =>
            {
                entity.HasKey(e => e.UnitComplaintsId)
                    .HasName("PK__UnitComp__25DAF4606C52D161");

                entity.Property(e => e.UnitComplaintsId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UnitComplaintsID");

                entity.Property(e => e.ComplaintId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("complaintID");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("unitID");

                entity.HasOne(d => d.Complaint)
                    .WithMany(p => p.UnitComplaints)
                    .HasForeignKey(d => d.ComplaintId)
                    .HasConstraintName("FK__UnitCompl__compl__2F10007B");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.UnitComplaints)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__UnitCompl__unitI__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
