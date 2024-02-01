using Microsoft.EntityFrameworkCore;
using SCRINTest.Models.DB;

namespace SCRINTest.Context;

public partial class ScrintestContext : DbContext
{
    public ScrintestContext()
    {
    }

    public ScrintestContext(DbContextOptions<ScrintestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuyingProduct> BuyingProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsByuingProduct> ProductsByuingProducts { get; set; }

    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=SCRINTest;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuyingProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BuyingPr__3213E83F1BF030E1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.PlacementDate).HasColumnName("placementDate");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F0F5A9EF5");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<ProductsByuingProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F83D91EEE");

            entity.ToTable("Products_ByuingProducts");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.IdByuingProduct).HasColumnName("idByuingProduct");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");

            entity.HasOne(d => d.ByuingProductNavigation).WithMany(p => p.ProductsByuingProducts)
                .HasForeignKey(d => d.IdByuingProduct)
                .HasConstraintName("FK__Orders__buyingPr__3B75D760");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductsByuingProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__Orders__productI__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
