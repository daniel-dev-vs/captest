using CapptaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapptaApi.Repository
{
    interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> ConsultaPorCnpj(string cnpj, int bandeira);
        Task<IEnumerable<Transacao>> ConsultaPorData(DateTime data, int bandeira);
        Task<IEnumerable<Transacao>> ConsultaPorBandeira(string bandeira);
        Task<IEnumerable<Transacao>> ConsultaPorAdquirente(string adquirente);
        Task<IEnumerable<Transacao>> ConsultaPorCnpjDataAtualMastercard(string bandeira);
        Task<IEnumerable<Transacao>> ConsultaPorStoneÙltimos30Dias(string bandeira);
    }
}
