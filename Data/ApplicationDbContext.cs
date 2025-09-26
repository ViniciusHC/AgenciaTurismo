using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Models.Destino> Destinos { get; set; }
        public DbSet<Models.Reserva> Reservas { get; set; }
        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Models.PacoteTuristico> PacotesTuristicos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.PacoteTuristico)
                .HasForeignKey(r => r.PacoteTuristicoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("TEXT");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("TEXT");
                entity.Property(e => e.SecurityStamp).HasColumnType("TEXT");
                entity.Property(e => e.PhoneNumber).HasColumnType("TEXT");
            });
        }
    }
}
