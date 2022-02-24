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
        public virtual DbSet<CrachaAluno> CrachaAlunos { get; set; }
        public virtual DbSet<CrachaProfessor> CrachaProfessors { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=NOTE0113D3\\SQLEXPRESS; initial catalog=CAROMETRO; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__aluno__0C5BC849CDB0A756");

                entity.ToTable("aluno");

                entity.HasIndex(e => e.Matricula, "UQ__aluno__30962D15238B94FA")
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
                    .HasConstraintName("FK__aluno__idTurma__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aluno__idUsuario__4F7CD00D");
            });

            modelBuilder.Entity<CrachaAluno>(entity =>
            {
                entity.HasKey(e => e.IdCracha)
                    .HasName("PK__crachaAl__2B5384376424DD3C");

                entity.ToTable("crachaAluno");

                entity.HasIndex(e => e.Token, "UQ__crachaAl__CA90DA7A74E9481B")
                    .IsUnique();

                entity.Property(e => e.IdCracha).HasColumnName("idCracha");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.CrachaAlunos)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__crachaAlu__idAlu__571DF1D5");
            });

            modelBuilder.Entity<CrachaProfessor>(entity =>
            {
                entity.HasKey(e => e.IdCracha)
                    .HasName("PK__crachaPr__2B5384371DCBA41F");

                entity.ToTable("crachaProfessor");

                entity.HasIndex(e => e.Token, "UQ__crachaPr__CA90DA7AA7868AD8")
                    .IsUnique();

                entity.Property(e => e.IdCracha).HasColumnName("idCracha");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.CrachaProfessors)
                    .HasForeignKey(d => d.IdProfessor)
                    .HasConstraintName("FK__crachaPro__idPro__534D60F1");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB0090E59E5E");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.NumeroInstituicao, "UQ__institui__2E6437CA4463A071")
                    .IsUnique();

                entity.HasIndex(e => e.NomeInstituicao, "UQ__institui__E28517EA84962713")
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
                    .HasName("PK__periodo__90A7D3D8AC4B1DB3");

                entity.ToTable("periodo");

                entity.HasIndex(e => e.NomePeriodo, "UQ__periodo__1E82E37C46D4A817")
                    .IsUnique();

                entity.Property(e => e.IdPeriodo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPeriodo");

                entity.Property(e => e.NomePeriodo).HasColumnName("nomePeriodo");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__professo__4E7C3C6D06D11685");

                entity.ToTable("professor");

                entity.HasIndex(e => e.Matricula, "UQ__professo__30962D15B21FF994")
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
                    .HasConstraintName("FK__professor__idUsu__440B1D61");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF20E2B229");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9FB157B490")
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
                    .HasName("PK__turma__AA0683109A30B10F");

                entity.ToTable("turma");

                entity.HasIndex(e => e.NomeTurma, "UQ__turma__3798BCA69E3B6A22")
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
                    .HasConstraintName("FK__turma__idPeriodo__4AB81AF0");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6ABA6923D");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Rg, "UQ__usuario__32143310475A4717")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61644587DAFB")
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
                    .HasConstraintName("FK__usuario__idInsti__403A8C7D");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
