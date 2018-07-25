using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;

namespace CapptaApi.Services
{
    public interface ITransacaoService
    {
        Task<List<Transacao>> ConsultaPorCnpj(string cnpj);
        Task<List<Transacao>> ConsultaPorCnpjEBandeira(string cnpj, string bandeira);
        Task<List<Transacao>> ConsultaPorCnpjMasterEVisa(string cnpj);
        Task<List<Transacao>> ConsultaPorData(DateTime data, string bandeira);
        Task<List<Transacao>> ConsultaPorBandeira(string bandeira);
        Task<List<Transacao>> ConsultaPorAdquirente(string adquirente, string bandeira);
        Task<List<Transacao>> ConsultaPorCnpjDataAtualMastercard(string cnpj);
        Task<List<Transacao>> ConsultaPorCnpjStoneUltimos30Dias(string cnpj);

    }
}
