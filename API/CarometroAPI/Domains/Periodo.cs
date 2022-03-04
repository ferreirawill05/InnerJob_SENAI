using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Periodo
    {
        public Periodo()
        {
            Turmas = new HashSet<Turma>();
        }

        public byte IdPeriodo { get; set; }
        public string NomePeriodo { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
