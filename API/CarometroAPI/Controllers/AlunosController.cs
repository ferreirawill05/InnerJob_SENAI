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
    public class AlunosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IAlunoRepository _alunoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public AlunosController()
        {
            _alunoRepository = new AlunoRepository();
        }

        /// <summary>
        /// Lista todos os Alunos existentes
        /// </summary>
        /// <returns>Uma lista de alunos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_alunoRepository.Listar());
        }

        /// <summary>
        /// Busca um aluno pelo id
        /// </summary>
        /// <param name="idAluno">id do aluno a ser buscado</param>
        /// <returns>Um aluno encontrado com status code - 200</returns>
        [HttpGet("{idAluno}")]
        public IActionResult BuscarPorId(int idAluno)
        {
            Aluno alunoBuscado = _alunoRepository.BuscarPorId(idAluno);

            if (alunoBuscado == null)
            {
                return NotFound("O Aluno informado não existe!");
            }
            return Ok(alunoBuscado);
        }

        /// <summary>
        /// Cadastra um Aluno
        /// </summary>
        /// <param name="novoAluno">Aluno a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Aluno novoAluno)
        {
            _alunoRepository.Cadastrar(novoAluno);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um aluno existente
        /// </summary>
        /// <param name="alunoAtualizado">Objeto com as novas informações do Aluno e o id do aluno a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Aluno alunoAtualizado)
        {
            try
            {
                Aluno alunoBuscado = _alunoRepository.BuscarPorId(alunoAtualizado.IdAluno);
                if (alunoBuscado != null)
                {
                    if (alunoAtualizado != null)
                        _alunoRepository.Atualizar(alunoAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O aluno informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um aluno
        /// </summary>
        /// <param name="idAluno">id do Aluno a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idAluno}")]
        public IActionResult Deletar(int idAluno)
        {
            _alunoRepository.Deletar(idAluno);

            return StatusCode(204);
        }
    }
}
