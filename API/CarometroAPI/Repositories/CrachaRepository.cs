using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class CrachaRepository : ICrachaRepository
    {
        CarometroContext ctx = new CarometroContext();
        
        List<int> lista = new List<int>();
        
        public void Atualizar(Cracha crachaAtualizado)
        {
            Cracha crachaBuscado = BuscarPorId(crachaAtualizado.IdCracha);

            if (crachaAtualizado.IdUsuario != null)
            {
                crachaBuscado.IdUsuario = crachaAtualizado.IdUsuario;
            }

            if (crachaAtualizado.Token != null)
            {
                crachaBuscado.Token = crachaAtualizado.Token;
            }

            ctx.Crachas.Update(crachaBuscado);

            ctx.SaveChanges();
        }

        public Cracha BuscarPorId(int idCracha)
        {
            return ctx.Crachas.FirstOrDefault(u => u.IdCracha == idCracha);
        }
            
        public void Cadastrar(Cracha novoCracha)
        {
            ctx.Crachas.Add(novoCracha);

            ctx.SaveChanges();
        }

        public void Deletar(int idCracha)
        {
            Cracha crachaBuscado = BuscarPorId(idCracha);

            ctx.Crachas.Remove(crachaBuscado);

            ctx.SaveChanges();
        }

        public void GerarToken(int idCracha)
        {
            Cracha crachaBuscado = BuscarPorId(idCracha);

            Random R = new Random();

            foreach (int list in lista)
            {
                int numer = R.Next(999999999);

                if(numer == list) {

                    numer = R.Next(999999999);
                }
                else
                {
                    lista.Add(numer);
                    crachaBuscado.Token = numer.ToString();

                    ctx.Crachas.Update(crachaBuscado);

                    ctx.SaveChanges();
                }
            }
        }

        public List<Cracha> Listar()
        {
            return ctx.Crachas.ToList();
        }
    }
}
