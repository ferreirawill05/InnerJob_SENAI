using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class CrachaAluno
    {
        public short IdCracha { get; set; }
        public short? IdAluno { get; set; }
        public string Token { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
