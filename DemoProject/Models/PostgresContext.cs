using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersTovar> OrdersTovars { get; set; }

    public virtual DbSet<Postavchiki> Postavchikis { get; set; }

    public virtual DbSet<Proizvoditeli> Proizvoditelis { get; set; }

    public virtual DbSet<PunktVydach> PunktVydaches { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Port=5432;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderCode).HasColumnName("order_code");
            entity.Property(e => e.OrderCreateDate).HasColumnName("order_create_date");
            entity.Property(e => e.OrderDeliverDate).HasColumnName("order_deliver_date");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.PvId).HasColumnName("pv_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Pv).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_pv_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_user_id_fkey");
        });

        modelBuilder.Entity<OrdersTovar>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.TovarArticul }).HasName("order_tovar_pkey");

            entity.ToTable("orders_tovars");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.TovarArticul).HasColumnName("tovar_articul");
            entity.Property(e => e.OrdTovCount).HasColumnName("ord_tov_count");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersTovars)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_tovars_order_id_fkey");

            entity.HasOne(d => d.TovarArticulNavigation).WithMany(p => p.OrdersTovars)
                .HasForeignKey(d => d.TovarArticul)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_tovars_tovar_articul_fkey");
        });

        modelBuilder.Entity<Postavchiki>(entity =>
        {
            entity.HasKey(e => e.PostavId).HasName("postavchiki_pkey");

            entity.ToTable("postavchiki");

            entity.Property(e => e.PostavId)
                .ValueGeneratedNever()
                .HasColumnName("postav_id");
            entity.Property(e => e.PostavName).HasColumnName("postav_name");
        });

        modelBuilder.Entity<Proizvoditeli>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("proizvoditeli_pkey");

            entity.ToTable("proizvoditeli");

            entity.Property(e => e.ProizvodId)
                .ValueGeneratedNever()
                .HasColumnName("proizvod_id");
            entity.Property(e => e.ProizvodName).HasColumnName("proizvod_name");
        });

        modelBuilder.Entity<PunktVydach>(entity =>
        {
            entity.HasKey(e => e.PvId).HasName("punkt_vydach_pkey");

            entity.ToTable("punkt_vydach");

            entity.Property(e => e.PvId).HasColumnName("pv_id");
            entity.Property(e => e.PvAddress).HasColumnName("pv_address");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.TovarArticul).HasName("tovars_pkey");

            entity.ToTable("tovars");

            entity.Property(e => e.TovarArticul).HasColumnName("tovar_articul");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.PostavId).HasColumnName("postav_id");
            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.TovarActiveDiscount).HasColumnName("tovar_active_discount");
            entity.Property(e => e.TovarCountOnSklad).HasColumnName("tovar_count_on_sklad");
            entity.Property(e => e.TovarDescription).HasColumnName("tovar_description");
            entity.Property(e => e.TovarImage).HasColumnName("tovar_image");
            entity.Property(e => e.TovarIzmer).HasColumnName("tovar_izmer");
            entity.Property(e => e.TovarPrice).HasColumnName("tovar_price");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_category_id_fkey");

            entity.HasOne(d => d.Postav).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.PostavId)
                .HasConstraintName("tovars_postav_id_fkey");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_proizvod_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_type_id_fkey");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("types_pkey");

            entity.ToTable("types");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.TypeName).HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserFio).HasColumnName("user_fio");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
