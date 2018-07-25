using System;
using Xunit;
using CapptaApi.Repositories;
using CapptaApi.Constantes;


namespace XUnitTestCapptaAppi
{
    public class LeitorCsvRepositoryTest
    {
        protected LeitorCsvRepository RepositorioSobreTeste { get; }        
        protected string Caminho { get; set; }


        public LeitorCsvRepositoryTest()
        {
            Caminho = Const.DadosCsv;
            RepositorioSobreTeste = new LeitorCsvRepository();
            
        }

        public class LerCsvParaTransacaoModelArgumentException : LeitorCsvRepositoryTest
        {
            [Fact]
            public void LerCSVParaListaTransacaoModelArgumentException()
            {
                // Arrange, Act, Assert
                Caminho = "";
                var excecao = Assert.Throws<ArgumentException>(() => RepositorioSobreTeste.LerCSVParaListaTransacaoModel(Caminho));
                
            }
        }

        public class LerCsvParaTransacaoModelArgumentNullException : LeitorCsvRepositoryTest
        {
            [Fact]
            public void LerCSVParaListaTransacaoModelExcecao()
            {
                // Arrange, Act, Assert
                Caminho = null;
                var excecao = Assert.Throws<ArgumentNullException>(() => RepositorioSobreTeste.LerCSVParaListaTransacaoModel(null));

            }
        }

        public class LerCsvParaTransacaoModel : LeitorCsvRepositoryTest
        {
            [Fact]
            public void LerCSVParaListaTransacaoModelExcecao()
            {
                // Arrange, Act
                
                var transacaoes = RepositorioSobreTeste.LerCSVParaListaTransacaoModel(Caminho);
                
                //Assert
                Assert.True(transacaoes.Count == 200);
                

            }
        }
    }

}

