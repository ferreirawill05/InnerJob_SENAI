using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IInstituicaoRepository
    {
        Instituicao BuscarPorId(int idInstituicao);
        void Cadastrar(Instituicao novoUsuario);
        List<Instituicao> Listar();
        void Atualizar(Instituicao usuarioAtualizado);
        void Deletar(int idUsuario);
    }
}
