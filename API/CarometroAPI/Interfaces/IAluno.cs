using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IAluno
    {
        Aluno Cadastrar(Aluno novoUsuario);
        List<Aluno> Listar();
        void Atualizar(Aluno usuarioAtualizado);
        void Deletar(int idUsuario);
    }
}
