using CarometroAPI.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        Usuario BuscarPorId(int idUsuario);
        void Cadastrar(Usuario novoUsuario);
        List<Usuario> Listar();
        void Atualizar(Usuario usuarioAtualizado);
        void Deletar(int idUsuario);
        void SalvarImagem(IFormFile foto, int idUsuario);
        void ConsultarImagem(int idUsuario);
        void CriarPasta();

    }
}
