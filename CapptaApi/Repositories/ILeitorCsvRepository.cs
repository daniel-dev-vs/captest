using CapptaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapptaApi.Repositories
{
    public interface ILeitorCsvRepository
    {
        List<Transacao>LerCSVParaListaTransacaoModel(string caminho);
    }
}
