using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TryCoreTestDeveloper.DataAccess.Entity;

namespace TryCoreTestDeveloper.DataAccess.Configuration
{
    public partial class TryCoreTestBdContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }
        public TryCoreTestBdContext()
        {
        }

        public TryCoreTestBdContext(DbContextOptions<TryCoreTestBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MonMonedaEntity> MonMoneda { get; set; }
        public virtual DbSet<UsrUsuarioEntity> UsrUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Initial Catalog=TestDB;Persist Security Info=True;User ID=prueba;Password=pruebaconcepto;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<MonMonedaEntity>(entity =>
            {
                entity.ToTable("mon_moneda");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<UsrUsuarioEntity>(entity =>
            {
                entity.ToTable("usr_usuarios");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Direccion).HasMaxLength(250);

                entity.Property(e => e.Identificacion).HasMaxLength(50);

                entity.HasOne(d => d.Moneda)
                    .WithMany(p => p.UsrUsuarioEntity)
                    .HasForeignKey(d => d.MonedaId)
                    .HasConstraintName("FK_Usuarios_Monedas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}