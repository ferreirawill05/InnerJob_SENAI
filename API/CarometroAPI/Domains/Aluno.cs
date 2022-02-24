﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Aluno
    {
        public Aluno()
        {
            CrachaAlunos = new HashSet<CrachaAluno>();
        }

        public short IdAluno { get; set; }
        public byte? IdTurma { get; set; }
        public short? IdUsuario { get; set; }
        public string Matricula { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<CrachaAluno> CrachaAlunos { get; set; }
    }
}
