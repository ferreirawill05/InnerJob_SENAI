using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        CarometroContext ctx = new CarometroContext();
        public void Atualizar(Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = ctx.Instituicaos.FirstOrDefault(i => i.IdInstituicao == instituicaoAtualizada.IdInstituicao);

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

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicaos.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int idInstituicao)
        {
            Instituicao instituicaoBuscada = ctx.Instituicaos.FirstOrDefault(i => i.IdInstituicao == idInstituicao);

            ctx.Instituicaos.Remove(instituicaoBuscada);

            ctx.SaveChanges();
        }
    }
}
