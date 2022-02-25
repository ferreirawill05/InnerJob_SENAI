using CarometroAPI.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IUsuario
    {
        Usuario Login(string email, string senha);
        Usuario BuscarPorId(int id);
        Usuario Cadastrar(Usuario novoUsuario);
        List<Usuario> Listar();
        void Atualizar(Usuario usuarioAtualizado);
        void Deletar(int idUsuario);
        void SalvarImagem(IFormFile foto, int idUsuario);
        void ConsultarImagem(int idUsuario);
        void CriarPasta();

    }
}
