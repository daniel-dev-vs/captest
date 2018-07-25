using CapptaApi.Models;
using CapptaApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CapptaApi.Constantes;
using System.Threading.Tasks;
using System.Linq;

namespace XUnitTestCapptaAppi.Repositories
{
    public class TransacaoRepositoryTest
    {
        protected LeitorCsvRepository LeitorCsvRepository { get; }
        protected List<Transacao> Transacoes { get; set; }
        protected TransacaoRepository RepositorioSobreTeste { get;}

        public TransacaoRepositoryTest()
        {
            var transacoes = new LeitorCsvRepository().LerCSVParaListaTransacaoModel(Conts.DadosCsv);
            RepositorioSobreTeste = new TransacaoRepository(transacoes);

        }

        public class ConsultaPorAdquirente : TransacaoRepositoryTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Adquirente()
            {
                //Act.
                var adquirente = "Cielo";
                var result = await RepositorioSobreTeste.ConsultaPorAdquirente(adquirente);
                
                //Assert
                Assert.Equal(adquirente, result.FirstOrDefault().AcquirerName);
            }
        }
    }
}
