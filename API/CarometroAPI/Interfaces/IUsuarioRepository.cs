using CarometroAPI.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CarometroAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        Usuario BuscarPorId(int idUsuario);
        List<Usuario> ListarMeu(int id);
        void Cadastrar(Usuario novoUsuario);
        System.Collections.Generic.List<Usuario> Listar();
        void Atualizar(Usuario usuarioAtualizado);
        void Deletar(int idUsuario);
        void SalvarImagem(IFormFile foto, int idUsuario);
        string ConsultarImagem(int idUsuario);
        void CriarPasta();

    }
}
