using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;
using CapptaApi.Repository;

namespace CapptaApi.Services
{
    public class TransacaoService : ITransacaoService
    {
        private ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository ?? throw new ArgumentNullException(nameof(transacaoRepository));
        }

        public Task<List<Transacao>> ConsultaPorAdquirente(string adquirente, string bandeira)
        {
            return _transacaoRepository.ConsultaPorAdquirente(adquirente, bandeira);
        }

        public Task<List<Transacao>> ConsultaPorBandeira(string bandeira)
        {
            return _transacaoRepository.ConsultaPorBandeira(bandeira);
        }

        public Task<List<Transacao>> ConsultaPorCnpj(string cnpj)
        {
            return _transacaoRepository.ConsultaPorCnpj(cnpj);            
        }

        public Task<List<Transacao>> ConsultaPorCnpjDataAtualMastercard(string cnpj)
        {
            return _transacaoRepository.ConsultaPorCnpjDataAtualMastercard(cnpj);
        }

        public Task<List<Transacao>> ConsultaPorCnpjEBandeira(string cnpj, string bandeira)
        {
            return _transacaoRepository.ConsultaPorCnpjEBandeira(cnpj, bandeira);
        }

        public Task<List<Transacao>> ConsultaPorCnpjMasterEVisa(string cnpj)
        {
            return _transacaoRepository.ConsultaPorCnpjMasterEVisa(cnpj);
        }

        public Task<List<Transacao>> ConsultaPorCnpjStoneUltimos30Dias(string cnpj)
        {
            return _transacaoRepository.ConsultaPorCnpjStoneUltimos30Dias(cnpj);
        }

        public Task<List<Transacao>> ConsultaPorData(DateTime data, string bandeira)
        {
            return _transacaoRepository.ConsultaPorData(data, bandeira);
        }


    }
}
