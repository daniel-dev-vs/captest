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
        private readonly IEnumerable<Transacao> _trancacoes;
        public TransacaoRepository(IEnumerable<Transacao> transacoes)
        {
            if (transacoes == null) { throw new ArgumentNullException(nameof(_trancacoes)); }            
            _trancacoes = transacoes;
        }

        public Task<IEnumerable<Transacao>> ConsultaPorAdquirente(string adquirente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ConsultaPorBandeira(string bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ConsultaPorCnpj(string cnpj, int bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ConsultaPorCnpjDataAtualMastercard(string bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ConsultaPorData(DateTime data, int bandeira)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> ConsultaPorStoneÙltimos30Dias(string bandeira)
        {
            throw new NotImplementedException();
        }

       
        }
    }
}
