using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IInstituicao
    {
        Instituicao Cadastrar(Instituicao novoUsuario);
        List<Instituicao> Listar();
        void Atualizar(Instituicao usuarioAtualizado);
        void Deletar(int idUsuario);
    }
}
