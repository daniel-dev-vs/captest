using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;

namespace CapptaApi.Services
{
    interface ITransacaoService
    {
        IEnumerable<Transacao> ConsultaPorCnpj(string cnpj, int bandeira);
        IEnumerable<Transacao> ConsultaPorData(DateTime data, int bandeira);
        IEnumerable<Transacao> ConsultaPorBandeira(string bandeira);
        IEnumerable<Transacao> ConsultaPorAdquirente(string adquirente);
        IEnumerable<Transacao> ConsultaPorCnpjDataAtualMastercard(string bandeira);
        IEnumerable<Transacao> ConsultaPorStoneÙltimos30Dias(string bandeira);

    }
}
