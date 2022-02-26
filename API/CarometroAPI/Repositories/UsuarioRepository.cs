using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using CarometroAPI.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        CarometroContext ctx = new CarometroContext();
        public void Atualizar(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(usuarioAtualizado.IdUsuario);

            if (usuarioAtualizado.IdTipoUsuario != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            if (usuarioAtualizado.IdInstituicao != null)
            {
                usuarioBuscado.IdInstituicao = usuarioAtualizado.IdInstituicao;
            }

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            if (usuarioAtualizado.Rg != null)
            {
                usuarioBuscado.Rg = usuarioAtualizado.Rg;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            if (usuarioAtualizado.Imagem != null)
            {
                usuarioBuscado.Imagem = usuarioAtualizado.Imagem;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public string ConsultarImagem(int idUsuario)
        {
            CriarPasta();

            string nome_novo = idUsuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }

        public void CriarPasta()
        {
            string pasta = "Perfil";

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuarioEncontrado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuarioEncontrado != null)
            {

                if (usuarioEncontrado.Senha.Length <= 50)
                {
                    usuarioEncontrado.Senha = Criptografia.GerarHash(usuarioEncontrado.Senha);

                    ctx.Usuarios.Update(usuarioEncontrado);

                    ctx.SaveChanges();
                }

                bool comparado = Criptografia.Comparar(senha, usuarioEncontrado.Senha);

                if (comparado)
                    return usuarioEncontrado;
            }

            return null;
        }

        public void SalvarImagem(IFormFile foto, int idUsuario)
        {
            string nome_novo = idUsuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("Perfil", nome_novo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
