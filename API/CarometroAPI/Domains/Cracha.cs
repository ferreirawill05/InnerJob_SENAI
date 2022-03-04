using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Cracha
    {
        public short IdCracha { get; set; }
        public short? IdUsuario { get; set; }
        public string Token { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
