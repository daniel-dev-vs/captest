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
            var transacoes = new LeitorCsvRepository().LerCSVParaListaTransacaoModel(Const.DadosCsv);
            RepositorioSobreTeste = new TransacaoRepository(transacoes);

        }

        public class ConsultaPorAdquirente : TransacaoRepositoryTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Adquirente()
            {
                //Act.
                var adquirente = "Cielo";
                var bandeira = Const.Mastercard;
                var result = await RepositorioSobreTeste.ConsultaPorAdquirente(adquirente, bandeira);
                var primeiraTransacao = result.FirstOrDefault();
                //Assert

                Assert.Equal(adquirente, primeiraTransacao.AcquirerName);
                Assert.Equal(bandeira, primeiraTransacao.CardBrandName);
            }
        }

        public class ConsultaPorBandeira : TransacaoRepositoryTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Bandeira()
            {
                //Act.
                var bandeira = Const.Mastercard;                
                var result = await RepositorioSobreTeste.ConsultaPorBandeira(bandeira);

                //Assert
                Assert.Equal(bandeira, result.FirstOrDefault().CardBrandName);
            }
        }

        public class ConsultaPorCnpj : TransacaoRepositoryTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Cnpj()
            {
                //Act.
                var cnpj = "21442989000163";
                //var bandeira = null;               
                var result = await RepositorioSobreTeste.ConsultaPorCnpj(cnpj);

                //Assert
                Assert.Equal(cnpj, result.FirstOrDefault().MerchantCnpj);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_DataAtual_e_Mastercard()
            {
                //Act.
                var cnpj = "07638113000166";
                var bandeira = Const.Mastercard;                               
                var result = await RepositorioSobreTeste.ConsultaPorCnpjDataAtualMastercard(cnpj);

                //Assert
                Assert.Equal(cnpj, result.FirstOrDefault().MerchantCnpj);
                Assert.Equal(bandeira, result.FirstOrDefault().CardBrandName);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_e_Mastercard()
            {
                //Act.
                var cnpj = "07638113000166";
                var bandeira = Const.Mastercard;
                var result = await RepositorioSobreTeste.ConsultaPorCnpjEBandeira(cnpj, bandeira);

                //Assert
                Assert.Equal(cnpj, result.FirstOrDefault().MerchantCnpj);
                Assert.Equal(bandeira, result.FirstOrDefault().CardBrandName);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_e_Visa()
            {
                //Act.
                var cnpj = "17872744000107";
                var bandeira = Const.Visa;
                //var bandeira = null;               
                var result = await RepositorioSobreTeste.ConsultaPorCnpjEBandeira(cnpj, bandeira);

                //Assert
                Assert.Equal(cnpj, result.FirstOrDefault().MerchantCnpj);
                Assert.Equal(bandeira, result.FirstOrDefault().CardBrandName);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_Master_Visa()
            {
                //Act.
                var cnpj = "21442989000163";
                
                
                //var bandeira = null;               
                var result = await RepositorioSobreTeste.ConsultaPorCnpjMasterEVisa(cnpj);


                //Assert
                Assert.Equal(cnpj, result.FirstOrDefault().MerchantCnpj);
                Assert.Equal(Const.Mastercard,
                    result.FirstOrDefault(x => x.CardBrandName == Const.Mastercard).CardBrandName);
                Assert.Equal(Const.Visa,
                   result.FirstOrDefault(x => x.CardBrandName == Const.Visa).CardBrandName);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_Stone_Ultimos_30_Dias()
            {
                //Act.
                var cnpj = "17872744000107";

                //var bandeira = null;               
                var result = await RepositorioSobreTeste.ConsultaPorCnpjStoneUltimos30Dias(cnpj);
                DateTime dataUltimos30Dias = DateTime.Now.AddDays(-30);                

                //Assert
                Assert.True( result.FirstOrDefault().AcquirerAuthorizationDateTime > dataUltimos30Dias);
                
            }          
          
        }

        public class ConsultaPorData: TransacaoRepositoryTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Data_e_Bandeira()
            {
                //Act.
                var bandeira = Const.Mastercard;
                var data = DateTime.Now;
                var result = await RepositorioSobreTeste.ConsultaPorData(data, bandeira);

                //Assert
                Assert.Equal(bandeira, result.FirstOrDefault().CardBrandName);
                Assert.Equal(data, result.FirstOrDefault().AcquirerAuthorizationDateTime);
            }
        }
    }
}
