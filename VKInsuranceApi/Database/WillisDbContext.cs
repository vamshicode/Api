using Microsoft.EntityFrameworkCore;
using VKInsuranceApi.EntityModels;

namespace VKInsuranceApi.Database;

public partial class WillisDbContext : DbContext
{
    public WillisDbContext()
    {
    }

    public WillisDbContext(DbContextOptions<WillisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    //Not needed since configuration is set up in program.cs
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer();
    //    //("bServer=(localdb)\\MSSQLLocalDB;Database=willis;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__B611CB7D09919D0A");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerMiddleName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
