using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface ICracha
    {
        Cracha Cadastrar(Cracha novoUsuario);
        List<Cracha> Listar();
        void Atualizar(Cracha usuarioAtualizado);
        void Deletar(int idUsuario);
        void GerarToken();
    }
}
