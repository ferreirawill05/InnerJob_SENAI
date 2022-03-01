using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using CarometroAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarometroAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public InstituicoesController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as Instituições existentes
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma instituicao pelo id
        /// </summary>
        /// <param name="idInstituicao">id da instituicao a ser buscada</param>
        /// <returns>Uma instituicao encontrada com status code - 200</returns>
        [HttpGet("{idInstuicao}")]
        public IActionResult BuscarPorId(int idInstituicao)
        {
            Instituicao instituicaoBuscado = _instituicaoRepository.BuscarPorId(idInstituicao);

            if (instituicaoBuscado == null)
            {
                return NotFound("Uma instituição informado não existe!");
            }
            return Ok(instituicaoBuscado);
        }

        /// <summary>
        /// Cadastra uma Instituição
        /// </summary>
        /// <param name="novoInstituicao">Instituicao a ser cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Instituicao novoInstituicao)
        {
            _instituicaoRepository.Cadastrar(novoInstituicao);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações da instituicao e o id da instituicao a ser atualizada</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Instituicao instituicaoAtualizada)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(instituicaoAtualizada.IdInstituicao);
                if (instituicaoBuscada != null)
                {
                    if (instituicaoBuscada != null)
                        _instituicaoRepository.Atualizar(instituicaoAtualizada);
                }
                else
                {
                    return BadRequest(new { mensagem = "A instituicao informada não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // <summary>
        /// Deleta uma instituicao
        /// </summary>
        /// <param name="idUsuario">id da Instituicao a ser deletada</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idInstituicao}")]
        public IActionResult Deletar(int idInstituicao)
        {
            _instituicaoRepository.Deletar(idInstituicao);

            return StatusCode(204);
        }
    }
}
