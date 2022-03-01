using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        CarometroContext ctx = new CarometroContext();

        public void Atualizar(Aluno alunoAtualizado)
        {
            Aluno alunoBuscado = BuscarPorId(alunoAtualizado.IdAluno);

            if (alunoAtualizado.IdUsuario != null)
            {
                alunoBuscado.IdUsuario = alunoAtualizado.IdUsuario;
            }

            if (alunoAtualizado.IdTurma != null)
            {
                alunoBuscado.IdTurma = alunoAtualizado.IdTurma;
            }

            if (alunoAtualizado.Matricula != null)
            {
                alunoBuscado.Matricula = alunoAtualizado.Matricula;
            }

            ctx.Alunos.Update(alunoBuscado);

            ctx.SaveChanges();
        }

        public Aluno BuscarPorId(int idAluno)
        {
            return ctx.Alunos.FirstOrDefault(u => u.IdAluno == idAluno);
        }

        public void Cadastrar(Aluno novoAluno)
        {
            ctx.Alunos.Add(novoAluno);

            ctx.SaveChanges();
        }

        public void Deletar(int idAluno)
        {
            Aluno alunoBuscado = BuscarPorId(idAluno);

            ctx.Alunos.Remove(alunoBuscado);

            ctx.SaveChanges();
        }

        public System.Collections.Generic.List<Aluno> Listar()
        {
            return ctx.Alunos.ToList();
        }
    }
}
