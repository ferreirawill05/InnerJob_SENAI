using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using CarometroAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarometroAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CrachasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private ICrachaRepository _crachaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public CrachasController()
        {
            _crachaRepository = new CrachaRepository();
        }

        /// <summary>
        /// Lista todos os Crachás existentes
        /// </summary>
        /// <returns>Uma lista de crachás</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_crachaRepository.Listar());
        }

        /// <summary>
        /// Busca um crachá pelo id
        /// </summary>
        /// <param name="idCracha">id do crachá a ser buscado</param>
        /// <returns>Um crachá encontrado com status code - 200</returns>
        [HttpGet("{idCracha}")]
        public IActionResult BuscarPorId(int idCracha)
        {
            Cracha crachaBuscado = _crachaRepository.BuscarPorId(idCracha);

            if (crachaBuscado == null)
            {
                return NotFound("O Crachá informado não existe!");
            }
            return Ok(crachaBuscado);
        }

        /// <summary>
        /// Cadastra um Cracha
        /// </summary>
        /// <param name="novoCracha">Cracha a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Cracha novoCracha)
        {
            _crachaRepository.Cadastrar(novoCracha);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um cracha existente
        /// </summary>
        /// <param name="crachaAtualizado">Objeto com as novas informações do Cracha e o id do cracha a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Cracha crachaAtualizado)
        {
            try
            {
                Cracha crachaBuscado = _crachaRepository.BuscarPorId(crachaAtualizado.IdCracha);
                if (crachaBuscado != null)
                {
                    if (crachaAtualizado != null)
                        _crachaRepository.Atualizar(crachaAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O cracha informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{idCracha}")]
        public IActionResult GerarToken(int idCracha)
        {
            try
            {
                Cracha crachaBuscado = _crachaRepository.BuscarPorId(idCracha);
                if (crachaBuscado != null)
                {
                        _crachaRepository.GerarToken(idCracha);
                }
                else
                {
                    return BadRequest(new { mensagem = "O cracha informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um cracha
        /// </summary>
        /// <param name="idCracha">id do Cracha a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idCracha}")]
        public IActionResult Deletar(int idCracha)
        {
            _crachaRepository.Deletar(idCracha);

            return StatusCode(204);
        }
    }
}
