using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        CarometroContext ctx = new CarometroContext();
        public void Atualizar(Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = BuscarPorId(instituicaoAtualizada.IdInstituicao);

            if (instituicaoBuscada.NomeInstituicao != null)
            {
                instituicaoBuscada.NomeInstituicao = instituicaoAtualizada.NomeInstituicao;
            }

            if (instituicaoBuscada.EnderecoInstituicao != null)
            {
                instituicaoBuscada.EnderecoInstituicao = instituicaoAtualizada.EnderecoInstituicao;
            }

            if (instituicaoBuscada.NumeroInstituicao != null)
            {
                instituicaoBuscada.NumeroInstituicao = instituicaoAtualizada.NumeroInstituicao;
            }

            ctx.Instituicaos.Update(instituicaoBuscada);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int idInstituicao)
        {
            return ctx.Instituicaos.FirstOrDefault(u => u.IdInstituicao == idInstituicao);
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicaos.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int idInstituicao)
        {
            Instituicao instituicaoBuscada = BuscarPorId(idInstituicao);

            ctx.Instituicaos.Remove(instituicaoBuscada);

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicaos.ToList();
        }
    }
}
