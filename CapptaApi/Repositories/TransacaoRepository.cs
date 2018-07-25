using CapptaApi.Models;
using CapptaApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CapptaApi.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private List<Transacao> _trancacoes { get; set; }
        public TransacaoRepository(List<Transacao> transacoes)
        {
            if (transacoes == null) { throw new ArgumentNullException(nameof(_trancacoes)); }
            _trancacoes = transacoes;
        }

        public Task<List<Transacao>> ConsultaPorAdquirente(string adquirente)
        {
            var result =  _trancacoes.Where(x => x.AcquirerName == adquirente).ToList();

            return Task.FromResult(result);
        }

        public Task<List<Transacao>> ConsultaPorBandeira(string bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultaPorCnpj(string cnpj, int bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultaPorCnpjDataAtualMastercard(string bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultaPorData(DateTime data, int bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultaPorStoneÙltimos30Dias(string bandeira)
        {
            throw new NotImplementedException();
        }


    }
}

