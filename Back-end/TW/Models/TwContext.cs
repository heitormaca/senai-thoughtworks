using Microsoft.EntityFrameworkCore;

namespace TW.Models {
    public partial class TWContext : DbContext {
        public TWContext () { }

        public TWContext (DbContextOptions<TWContext> options) : base (options) { }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Classificado> Classificado { get; set; }
        public virtual DbSet<Equipamento> Equipamento { get; set; }
        public virtual DbSet<Imagemclassificado> Imagemclassificado { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer ("Server=.\\SQLEXPRESS;Database=TW;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Categoria> (entity => {
                entity.HasKey (e => e.IdCategoria)
                    .HasName ("PK__CATEGORI__CD54BC5ADE83F55E");

                entity.Property (e => e.NomeCategoria).IsUnicode (false);

                entity.Property (e => e.StatusCategoria).HasDefaultValueSql ("((1))");
            });

            modelBuilder.Entity<Classificado> (entity => {
                entity.HasKey (e => e.IdClassificado)
                    .HasName ("PK__CLASSIFI__946341BD65FDAB24");

                entity.Property (e => e.NumeroDeSerie).IsUnicode (false);

                entity.Property (e => e.StatusClassificado).HasDefaultValueSql ("((1))");

                entity.HasOne (d => d.IdEquipamentoNavigation)
                    .WithMany (p => p.Classificado)
                    .HasForeignKey (d => d.IdEquipamento)
                    .HasConstraintName ("FK__CLASSIFIC__id_eq__5535A963");
            });

            modelBuilder.Entity<Equipamento> (entity => {
                entity.HasKey (e => e.IdEquipamento)
                    .HasName ("PK__EQUIPAME__B5F07F5C17AD9718");

                entity.Property (e => e.Alimentacao).IsUnicode (false);

                entity.Property (e => e.Dimensoes).IsUnicode (false);

                entity.Property (e => e.Hd).IsUnicode (false);

                entity.Property (e => e.Marca).IsUnicode (false);

                entity.Property (e => e.MemoriaRam).IsUnicode (false);

                entity.Property (e => e.Modelo).IsUnicode (false);

                entity.Property (e => e.NomeEquipamento).IsUnicode (false);

                entity.Property (e => e.Peso).IsUnicode (false);

                entity.Property (e => e.PlacaDeVideo).IsUnicode (false);

                entity.Property (e => e.Polegada).IsUnicode (false);

                entity.Property (e => e.Processador).IsUnicode (false);

                entity.Property (e => e.SistemaOperacional).IsUnicode (false);

                entity.Property (e => e.Ssd).IsUnicode (false);

                entity.Property (e => e.StatusEquipamento).HasDefaultValueSql ("((1))");

                entity.HasOne (d => d.IdCategoriaNavigation)
                    .WithMany (p => p.Equipamento)
                    .HasForeignKey (d => d.IdCategoria)
                    .HasConstraintName ("FK__EQUIPAMEN__id_ca__5165187F");
            });

            modelBuilder.Entity<Imagemclassificado> (entity => {
                entity.HasKey (e => e.IdImagemClassificado)
                    .HasName ("PK__IMAGEMCL__8113F4369033141E");

                entity.Property (e => e.Imagem).IsUnicode (false);

                entity.HasOne (d => d.IdClassificadoNavigation)
                    .WithMany (p => p.Imagemclassificado)
                    .HasForeignKey (d => d.IdClassificado)
                    .HasConstraintName ("FK__IMAGEMCLA__id_cl__5812160E");
            });

            modelBuilder.Entity<Interesse> (entity => {
                entity.HasKey (e => e.IdInteresse)
                    .HasName ("PK__INTERESS__9AA7BC1A53E057D1");

                entity.Property (e => e.Comprador).HasDefaultValueSql ("((0))");

                entity.Property (e => e.DataInteresse).HasDefaultValueSql ("(getdate())");

                entity.Property (e => e.StatusInteresse).HasDefaultValueSql ("((1))");

                entity.HasOne (d => d.IdClassificadoNavigation)
                    .WithMany (p => p.Interesse)
                    .HasForeignKey (d => d.IdClassificado)
                    .HasConstraintName ("FK__INTERESSE__id_cl__5DCAEF64");

                entity.HasOne (d => d.IdUsuarioNavigation)
                    .WithMany (p => p.Interesse)
                    .HasForeignKey (d => d.IdUsuario)
                    .HasConstraintName ("FK__INTERESSE__id_us__5EBF139D");
            });

            modelBuilder.Entity<Usuario> (entity => {
                entity.HasKey (e => e.IdUsuario)
                    .HasName ("PK__USUARIO__4E3E04ADF5486FDE");

                entity.Property (e => e.CategoriaUsuario).HasDefaultValueSql ("((1))");

                entity.Property (e => e.Email).IsUnicode (false);

                entity.Property (e => e.ImagemUsuario).IsUnicode (false);

                entity.Property (e => e.NomeCompleto).IsUnicode (false);

                entity.Property (e => e.NomeUsuario).IsUnicode (false);

                entity.Property (e => e.Senha).IsUnicode (false);

                entity.Property (e => e.StatusUsuario).HasDefaultValueSql ("((1))");
            });

            OnModelCreatingPartial (modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}