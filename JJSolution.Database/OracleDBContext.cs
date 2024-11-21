using Microsoft.EntityFrameworkCore;

namespace JJSolution.DataBase
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aparelho> Aparelhos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Preco> Precos { get; set; }
        public DbSet<Alerta> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento Usuario -> Aparelhos
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Aparelhos)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração do relacionamento Aparelho -> Consumos
            modelBuilder.Entity<Aparelho>()
                .HasMany(a => a.Consumos)
                .WithOne(c => c.Aparelho)
                .HasForeignKey(c => c.AparelhoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração do relacionamento Consumo -> Preco
            modelBuilder.Entity<Consumo>()
                .HasOne(c => c.Preco)
                .WithMany()
                .HasForeignKey(c => c.PrecoId);

            // Configuração do relacionamento Usuario -> Alertas
            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Alertas)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

            // Constraint de Email único para Usuário
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("Data Source=your_datasource;User Id=your_user;Password=your_password;",
                    b => b.MigrationsAssembly("JJSolution.API"));
            }
        }
    }
}
