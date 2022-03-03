using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using CarometroAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CarometroAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuários existentes
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="idUsuario">id do usuário a ser buscado</param>
        /// <returns>Um usuário encontrado com status code - 200</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(idUsuario);

            if (usuarioBuscado == null)
            {
                return NotFound("O Usuário informado não existe!");
            }
            return Ok(usuarioBuscado);
        }

        /// <summary>
        /// Consulta a foto de perfil de um usuário
        /// </summary>
        /// <returns>A foto em base64</returns>
        [HttpGet("imagem")]
        public IActionResult salvaImagem()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarImagem(idUsuario);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um Usuário
        /// </summary>
        /// <param name="novoUsuario">Usuario a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Salva uma imagem de perfil do usuário
        /// </summary>
        /// <param name="arquivo">imagem a ser salva</param>
        /// <returns>Status code 200 - OK</returns>
        [HttpPost("imagem")]
        public IActionResult postDir(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length < 5000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });
                string extensao = arquivo.FileName.Split('.').Last();

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarImagem(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto com as novas informações do Usuário e o id do usuário a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(usuarioAtualizado.IdUsuario);
                if (usuarioBuscado != null)
                {
                    if (usuarioAtualizado != null)
                        _usuarioRepository.Atualizar(usuarioAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O usuário informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuario">id do Usuário a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
    }
}
