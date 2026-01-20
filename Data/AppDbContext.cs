using Microsoft.EntityFrameworkCore;
using SsiApi.Models;

namespace SsiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Ssi> Ssis { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasKey(e => e.Chapa);

                entity.Property(e => e.Chapa)
                      .HasColumnName("chapa")
                      .HasColumnType("char(6)");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .HasMaxLength(255);

                entity.Property(e => e.Ramal)
                .HasColumnName("ramal")
                .HasColumnType("char(4)");

                entity.Property(e => e.Senha)
                .HasColumnName("senha")
                .HasMaxLength(255);

                entity.Property(e => e.TipoUsuario)
                .HasColumnName("tipo_usuario")
                .HasMaxLength(255);

                entity.Property(e => e.Mostrar)
                .HasColumnName("mostrar")
                .HasColumnType("char(1)");

                entity.Property(e => e.AreaTecnico)
                .HasColumnName("area_tecnico")
                .HasMaxLength(50);
            });
            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");
                entity.HasKey(e => e.ServicoId);
                entity.Property(e => e.ServicoId).HasColumnName("servico_id");
                entity.Property(e => e.Mostrar).HasColumnName("mostrar").HasColumnType("char(1)");
                entity.Property(e => e.NomeServico).HasColumnName("nome_servico").HasMaxLength(100);
                entity.Property(e => e.AreaServico).HasColumnName("area_servico").HasMaxLength(50);
            });
            modelBuilder.Entity<Ssi>(entity =>
            {
                entity.ToTable("ssi");
                entity.HasKey(e => e.SsiId);
                entity.Property(e => e.SsiId).HasColumnName("ssi_id");

                entity.Property(e => e.ChapaSolicitante).HasColumnName("chapa_solicitante").HasColumnType("char(6)");
                entity.Property(e => e.NomeSolicitante).HasColumnName("nome_solicitante").HasMaxLength(255);
                entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
                entity.Property(e => e.Andamento).HasColumnName("andamento").HasMaxLength(50);
                entity.Property(e => e.ServicoId).HasColumnName("servico_id");

                entity.HasOne(e => e.Usuario).WithMany().HasForeignKey(e => e.ChapaSolicitante);
                entity.HasOne(e => e.Servico).WithMany().HasForeignKey(e => e.ServicoId);
            });
            modelBuilder.Entity<Historico>(entity =>
            {
                entity.ToTable("historico");
                entity.HasKey(e => e.HistoricoId);
                entity.Property(e => e.HistoricoId).HasColumnName("historico_id");
                entity.Property(e => e.DataAtualizacao).HasColumnName("data_atualizacao");
                entity.Property(e => e.DescricaoAtualizacao).HasColumnName("descricao_atualizacao");
                entity.Property(e => e.SsiId).HasColumnName("ssi_id");
                entity.Property(e => e.UsuarioId).HasColumnName("usuario_chapa");

                // 🔗 Relacionamentos
                entity.HasOne(e => e.Ssi)
                    .WithMany(s => s.Historicos)
                    .HasForeignKey(e => e.SsiId);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Historicos)
                    .HasForeignKey(e => e.UsuarioId);
            });
            modelBuilder.Entity<Peca>(entity =>
            {
                entity.ToTable("peca");
                entity.HasKey(e => e.PecaId);
                entity.Property(e => e.PecaId).HasColumnName("peca_id");
                entity.Property(e => e.DataPeca).HasColumnName("data_peca");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.Valor).HasColumnName("valor");
                entity.Property(e => e.SsiId).HasColumnName("ssi_id");
                entity.Property(e => e.UsuarioId).HasColumnName("fk_usuario_chapa");
                entity.HasOne(e => e.Ssi)
       .WithMany(s => s.Pecas)
       .HasForeignKey(e => e.SsiId);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Pecas)
                    .HasForeignKey(e => e.UsuarioId);
            });
        }

    }
}
