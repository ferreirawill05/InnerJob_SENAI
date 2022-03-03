using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public short IdInstituicao { get; set; }
        public string NomeInstituicao { get; set; }
        public string NumeroInstituicao { get; set; }
        public string EnderecoInstituicao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
