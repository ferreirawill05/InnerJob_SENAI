using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao novoUsuario);
        void Atualizar(Instituicao usuarioAtualizado);
        void Deletar(int idUsuario);
    }
}
