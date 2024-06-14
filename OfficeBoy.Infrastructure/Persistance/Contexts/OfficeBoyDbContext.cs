using Microsoft.EntityFrameworkCore;
using OfficeBoy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBoy.Infrastructure.Persistance.Contexts
{
    public class OfficeBoyDbContext : DbContext
    {

        public OfficeBoyDbContext(DbContextOptions<OfficeBoyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Drink> Drinks { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<OfficeBoyShift> OfficeBoyShifts { get; set; }

        public virtual DbSet<OfficeLocation> OfficeLocations { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FVF2DES\\SQLEXPRESS;Initial Catalog=OfficeOfficeBoyCleanArchitectureBoy;Integrated Security=True;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<DaysOfWeek>(entity =>
            {
                entity.HasKey(e => e.DayId).HasName("PK_Day_of_week");

                entity.ToTable("Days_of_weeks");

                entity.Property(e => e.DayId)
                    .ValueGeneratedNever()
                    .HasColumnName("day_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.Property(e => e.DeptId).HasColumnName("Dept_id");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.HasKey(e => e.DrinkId).HasName("PK__Drinks__C094D3C82DFE6600");

                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PictureURL");
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1688E7AB7");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.OfficeLocationId).HasColumnName("OfficeLocationID");
                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);


                entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.OfficeLocationId)
                    .HasConstraintName("FK__Employees__Offic__3587F3E0");


            });

            modelBuilder.Entity<OfficeBoyShift>(entity =>
            {
                entity.HasKey(e => e.ShiftId).HasName("PK__OfficeBo__C0A838E19181F165");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
                entity.Property(e => e.DayShift).HasColumnName("Day_Shift");
                entity.Property(e => e.EmpId).HasColumnName("emp_id");
                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");
                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_date");

                entity.HasOne(d => d.Emp).WithMany(p => p.OfficeBoyShifts)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeBoyShifts_Employees");
            });

            modelBuilder.Entity<OfficeLocation>(entity =>
            {
                entity.HasKey(e => e.OfficeLocationId).HasName("PK__OfficeLo__0B87E92C5B3A179F");

                entity.Property(e => e.OfficeLocationId).HasColumnName("OfficeLocationID");
                entity.Property(e => e.DeptId).HasColumnName("dept_id");
                entity.Property(e => e.FloorNumber).HasColumnName("Floor_number");
                entity.Property(e => e.LocationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept).WithMany(p => p.OfficeLocations)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeLocations_Departments");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__Orderes__C3905BAF43F7B5F3");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");
                entity.Property(e => e.EmpId).HasColumnName("emp_id");
                entity.Property(e => e.IsCompany).HasColumnName("Is_Company");
                entity.Property(e => e.OfficeLocationId).HasColumnName("OfficeLocationID");
                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Orderdate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderdate");

                entity.HasOne(d => d.Drink).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderes_Drinks");

                entity.HasOne(d => d.Emp).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderes_Employees");

                entity.HasOne(d => d.OfficeLocation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OfficeLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderes_OfficeLocations");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Orders");
            });


        }


    }
}
