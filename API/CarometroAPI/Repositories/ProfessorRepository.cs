using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        CarometroContext ctx = new CarometroContext();
        public void Atualizar(Professor professorAtualizado)
        {
            Professor professorBuscado = BuscarPorId(professorAtualizado.IdProfessor);

            if (professorAtualizado.IdUsuario != null)
            {
                professorBuscado.IdUsuario = professorAtualizado.IdUsuario;
            }

            if (professorAtualizado.Matricula != null)
            {
                professorBuscado.Matricula = professorAtualizado.Matricula;
            }

            ctx.Professors.Update(professorBuscado);

            ctx.SaveChanges();
        }

        public Professor BuscarPorId(int idProfessor)
        {
            return ctx.Professors.FirstOrDefault(u => u.IdProfessor == idProfessor);
        }

        public void Cadastrar(Professor novoProfessor)
        {
            ctx.Professors.Add(novoProfessor);

            ctx.SaveChanges();
        }

        public void Deletar(int idProfessor)
        {
            Professor professorBuscado = BuscarPorId(idProfessor);

            ctx.Professors.Remove(professorBuscado);

            ctx.SaveChanges();
        }

        public List<Professor> Listar()
        {
            return ctx.Professors.ToList();
        }
    }
}
