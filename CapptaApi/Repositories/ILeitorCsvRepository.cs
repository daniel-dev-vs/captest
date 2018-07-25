using CapptaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapptaApi.Repositories
{
    public interface ILeitorCsvRepository
    {
        IEnumerable<Transacao>LerCSVParaTransacaoModel(string caminho);
    }
}
