using CarometroAPI.Contexts;
using CarometroAPI.Domains;
using CarometroAPI.Interfaces;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarometroAPI.Repositories
{
    public class CrachaRepository : ICrachaRepository
    {
        CarometroContext ctx = new CarometroContext();
        
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

            var secretKey = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
            var totp = new Totp(secretKey);
            var otp = totp.ComputeTotp();

            crachaBuscado.Token = otp;
            crachaBuscado.UltimaAtualizacao = DateTime.Now;

            ctx.Crachas.Update(crachaBuscado);

            ctx.SaveChanges();

            }

        public List<Cracha> Listar()
        {
            return ctx.Crachas.ToList();
        }

        public bool ValidarToken(int idCracha)
        {
            Cracha crachaBuscado = BuscarPorId(idCracha);
            DateTime agora = DateTime.Now;
            DateTime antes = crachaBuscado.UltimaAtualizacao;

            TimeSpan verificacao = agora - antes;

            if(verificacao.TotalMinutes > 5)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
    
}

