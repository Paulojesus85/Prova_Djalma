using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unifaat.ProvaDjalma.Extensions;
using Unifaat.ProvaDjalma.Models;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entities<IStatusModificacao>(this, nameof(this.ModelStatusModificacao));
        }

        private void ModelStatusModificacao<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : class, IStatusModificacao
        {
            entity.HasQueryFilter(x => !x.Excluido);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            PreencheIStatusModificacao();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            PreencheIStatusModificacao();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PreencheIStatusModificacao()
        {

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null
                        && typeof(IStatusModificacao).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("Excluido").CurrentValue = true;
                }
            }

        }
    }
}