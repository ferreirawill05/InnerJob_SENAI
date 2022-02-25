using CarometroAPI.Domains;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IProfessor
    {
        Professor Cadastrar(Professor novoUsuario);
        List<Professor> Listar();
        void Atualizar(Professor usuarioAtualizado);
        void Deletar(int idUsuario);
    }
}
