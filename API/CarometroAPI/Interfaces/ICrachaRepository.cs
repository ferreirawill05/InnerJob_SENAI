using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface ICrachaRepository
    {
        Cracha BuscarPorId(int idCracha);
        void Cadastrar(Cracha novoCracha);
        List<Cracha> Listar();
        void Atualizar(Cracha crachaAtualizado);
        void Deletar(int idCracha);
        void GerarToken(int idCracha);
        bool ValidarToken(int idCracha);
    }
}
