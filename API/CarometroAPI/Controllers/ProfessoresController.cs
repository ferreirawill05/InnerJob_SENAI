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
    public class ProfessoresController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IProfessorRepository _professorRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public ProfessoresController()
        {
            _professorRepository = new ProfessorRepository();
        }

        /// <summary>
        /// Lista todos os professores existentes
        /// </summary>
        /// <returns>Uma lista de professores</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_professorRepository.Listar());
        }

        /// <summary>
        /// Busca um professor pelo id
        /// </summary>
        /// <param name="idProfessor">id do professor a ser buscado</param>
        /// <returns>Um professor encontrado com status code - 200</returns>
        [HttpGet("{idProfessor}")]
        public IActionResult BuscarPorId(int idProfessor)
        {
            Professor professorBuscado = _professorRepository.BuscarPorId(idProfessor);

            if (professorBuscado == null)
            {
                return NotFound("O Professor informado não existe!");
            }
            return Ok(professorBuscado);
        }

        /// <summary>
        /// Cadastra um Professor
        /// </summary>
        /// <param name="novoProfessor">Professor a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Professor novoProfessor)
        {
            _professorRepository.Cadastrar(novoProfessor);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um professor existente
        /// </summary>
        /// <param name="professorAtualizado">Objeto com as novas informações do Professor e o id do professor a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Professor professorAtualizado)
        {
            try
            {
                Professor professorBuscado = _professorRepository.BuscarPorId(professorAtualizado.IdProfessor);
                if (professorBuscado != null)
                {
                    if (professorAtualizado != null)
                        _professorRepository.Atualizar(professorAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O professor informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um professor
        /// </summary>
        /// <param name="idProfessor">id do Professor a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idProfessor}")]
        public IActionResult Deletar(int idProfessor)
        {
            _professorRepository.Deletar(idProfessor);

            return StatusCode(204);
        }
    }
}
