using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            CrachaProfessors = new HashSet<CrachaProfessor>();
        }

        public short IdProfessor { get; set; }
        public short? IdUsuario { get; set; }
        public string Matricula { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<CrachaProfessor> CrachaProfessors { get; set; }
    }
}
