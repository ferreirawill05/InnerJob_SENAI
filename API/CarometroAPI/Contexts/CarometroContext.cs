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
                //optionsBuilder.UseSqlServer("Data Source=NOTE0113D3\\SQLEXPRESS; initial catalog=CAROMETRO; user Id=sa; pwd=Senai@132;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113I2\\SQLEXPRESS; initial catalog=CAROMETRO; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__aluno__0C5BC849E6168699");

                entity.ToTable("aluno");

                entity.HasIndex(e => e.Matricula, "UQ__aluno__30962D151371E128")
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
                    .HasConstraintName("FK__aluno__idTurma__3C69FB99");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aluno__idUsuario__3D5E1FD2");
            });

            modelBuilder.Entity<Cracha>(entity =>
            {
                entity.HasKey(e => e.IdCracha)
                    .HasName("PK__cracha__2B538437EF3880E8");

                entity.ToTable("cracha");

                entity.HasIndex(e => e.Token, "UQ__cracha__CA90DA7AA2517718")
                    .IsUnique();

                entity.Property(e => e.IdCracha).HasColumnName("idCracha");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Crachas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__cracha__idUsuari__412EB0B6");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB0012A74025");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.NumeroInstituicao, "UQ__institui__2E6437CAE7FC5F9C")
                    .IsUnique();

                entity.HasIndex(e => e.NomeInstituicao, "UQ__institui__E28517EAFF77C97F")
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
                    .HasName("PK__periodo__90A7D3D8E4355915");

                entity.ToTable("periodo");

                entity.HasIndex(e => e.NomePeriodo, "UQ__periodo__1E82E37C3A5B53EA")
                    .IsUnique();

                entity.Property(e => e.IdPeriodo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPeriodo");

                entity.Property(e => e.NomePeriodo).HasColumnName("nomePeriodo");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__professo__4E7C3C6DA84C2155");

                entity.ToTable("professor");

                entity.HasIndex(e => e.Matricula, "UQ__professo__30962D15B5C07B75")
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
                    .HasName("PK__tipoUsua__03006BFF3B4DF9A8");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F3C19F82A")
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
                    .HasName("PK__turma__AA068310F0B3425C");

                entity.ToTable("turma");

                entity.HasIndex(e => e.NomeTurma, "UQ__turma__3798BCA635818CFB")
                    .IsUnique();

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
                    .HasConstraintName("FK__turma__idPeriodo__38996AB5");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6302BA1D5");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Rg, "UQ__usuario__321433108AA90179")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164E2CDDBC1")
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
                    .HasMaxLength(50)
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
