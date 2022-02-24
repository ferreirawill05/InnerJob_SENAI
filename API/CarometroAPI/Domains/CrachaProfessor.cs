using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class CrachaProfessor
    {
        public short IdCracha { get; set; }
        public short? IdProfessor { get; set; }
        public string Token { get; set; }

        public virtual Professor IdProfessorNavigation { get; set; }
    }
}
