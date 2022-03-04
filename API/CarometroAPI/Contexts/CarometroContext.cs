using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CarometroAPI.Domains;

#nullable disable

namespace CarometroAPI.Contexts
{
    public partial class CarometroContext : DbContext
    {
        public CarometroContext()
        {
        }

        public CarometroContext(DbContextOptions<CarometroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Cracha> Crachas { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE0113D3\\SQLEXPRESS; initial catalog=CAROMETRO; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__aluno__0C5BC84960C01BE2");

                entity.ToTable("aluno");

                entity.HasIndex(e => e.Matricula, "UQ__aluno__30962D1503140524")
                    .IsUnique();

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__aluno__idTurma__3B75D760");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aluno__idUsuario__3C69FB99");
            });

            modelBuilder.Entity<Cracha>(entity =>
            {
                entity.HasKey(e => e.IdCracha)
                    .HasName("PK__cracha__2B538437E42B270D");

                entity.ToTable("cracha");

                entity.HasIndex(e => e.Token, "UQ__cracha__CA90DA7A9D7E7F55")
                    .IsUnique();

                entity.Property(e => e.IdCracha).HasColumnName("idCracha");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UltimaAtualizacao)
                    .HasColumnType("datetime")
                    .HasColumnName("ultimaAtualizacao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Crachas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__cracha__idUsuari__403A8C7D");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB00C7B8145E");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.NumeroInstituicao, "UQ__institui__2E6437CAB660FCB7")
                    .IsUnique();

                entity.HasIndex(e => e.NomeInstituicao, "UQ__institui__E28517EA22F21658")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.EnderecoInstituicao)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("enderecoInstituicao");

                entity.Property(e => e.NomeInstituicao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeInstituicao");

                entity.Property(e => e.NumeroInstituicao)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("numeroInstituicao");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PK__periodo__90A7D3D86A8C3196");

                entity.ToTable("periodo");

                entity.HasIndex(e => e.NomePeriodo, "UQ__periodo__1E82E37C8019B990")
                    .IsUnique();

                entity.Property(e => e.IdPeriodo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPeriodo");

                entity.Property(e => e.NomePeriodo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomePeriodo");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__professo__4E7C3C6D6038BBD6");

                entity.ToTable("professor");

                entity.HasIndex(e => e.Matricula, "UQ__professo__30962D15F5DCDC1F")
                    .IsUnique();

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__professor__idUsu__31EC6D26");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF6CB7FB0F");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9FA6C228AD")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__turma__AA068310EFB4F891");

                entity.ToTable("turma");

                entity.Property(e => e.IdTurma)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTurma");

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.NomeTurma)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nomeTurma");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("FK__turma__idPeriodo__37A5467C");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A678CDF211");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Rg, "UQ__usuario__32143310BE99746B")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61648BC309C0")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("rg")
                    .IsFixedLength(true);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__usuario__idInsti__2E1BDC42");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
