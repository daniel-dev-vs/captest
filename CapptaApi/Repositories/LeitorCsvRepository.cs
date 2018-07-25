using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;

namespace CapptaApi.Repositories
{
    public class LeitorCsvRepository : ILeitorCsvRepository
    {
        public List<Transacao> LerCSVParaListaTransacaoModel(string caminho)
        {
            try
            {
                using (var reader = new StreamReader(caminho))
                {
                    List<Transacao> listaTransacao = new List<Transacao>();                    

                    while (!reader.EndOfStream)
                    {
                        var linha = reader.ReadLine();
                        var valores = linha.Split(';');

                        var transacao = new Transacao();

                        transacao.MerchantCnpj = valores[1];
                        transacao.CheckoutCode = Int32.Parse(valores[2]);
                        transacao.CipheredCardNumber = valores[3];
                        transacao.AmountInCents = Int32.Parse(valores[4]);
                        transacao.Installments = Int32.Parse(valores[5]);
                        transacao.AcquirerName = valores[6];
                        transacao.PaymentMethod = valores[7];
                        transacao.CardBrandName = valores[8];
                        transacao.Status = valores[9];
                        transacao.StatusInfo = valores[10];
                        transacao.CreatedAt = DateTime.Parse(valores[11]);
                        transacao.AcquirerAuthorizationDateTime = DateTime.Parse(valores[12]);

                        listaTransacao.Add(transacao);
                    }

                    return listaTransacao;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
    }
}
