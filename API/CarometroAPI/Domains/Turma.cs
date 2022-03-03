using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Turma
    {
        public Turma()
        {
            Alunos = new HashSet<Aluno>();
        }

        public byte IdTurma { get; set; }
        public byte? IdPeriodo { get; set; }
        public string NomeTurma { get; set; }

        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
