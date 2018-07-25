using CapptaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapptaApi.Repository
{
    interface ITransacaoRepository
    {
        Task<List<Transacao>> ConsultaPorCnpj(string cnpj, int bandeira);
        Task<List<Transacao>> ConsultaPorData(DateTime data, int bandeira);
        Task<List<Transacao>> ConsultaPorBandeira(string bandeira);
        Task<List<Transacao>> ConsultaPorAdquirente(string adquirente);
        Task<List<Transacao>> ConsultaPorCnpjDataAtualMastercard(string bandeira);
        Task<List<Transacao>> ConsultaPorStoneÙltimos30Dias(string bandeira);
    }
}
