using Microsoft.EntityFrameworkCore;

namespace PracticaN2_JosueZamoraConejo.Models
{
    public class FructicaDBContext:DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdCategoria> ProdCategorias { get; set; }

        public FructicaDBContext(DbContextOptions<FructicaDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(Producto =>
            {
                Producto.HasKey(e => e.Id);
                Producto.Property(n => n.Nombre).IsRequired().HasMaxLength(300);
                Producto.Property(n => n.Descripcion).IsRequired().HasMaxLength(500);
                Producto.Property(n => n.Precio).IsRequired().HasColumnType("float");
                Producto.Property(n => n.Cantidad).IsRequired().HasColumnType("int"); ;
        
            });
            modelBuilder.Entity<Categoria>(Categoria =>
            {
                Categoria.HasKey(e => e.Id);
                Categoria.Property(n => n.Nombre).IsRequired().HasMaxLength(300);

            });
            modelBuilder.Entity<ProdCategoria>()
                .HasKey(pc => new { pc.ProductoId, pc.CategoriaId });
          
            modelBuilder.Entity<ProdCategoria>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProdCategorias)
                .HasForeignKey(pc => pc.ProductoId);

            modelBuilder.Entity<ProdCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.ProdCategorias)
                .HasForeignKey(pc => pc.CategoriaId);
        }
    }
}
