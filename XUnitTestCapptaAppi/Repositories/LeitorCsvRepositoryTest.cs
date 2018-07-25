using System;
using Xunit;
using CapptaApi.Models;
using CapptaApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace XUnitTestCapptaAppi
{
    public class LeitorCsvRepositoryTest
    {
        protected LeitorCsvRepository RepositorioSobreTeste { get; }        
        protected string Caminho { get; set; }


        public LeitorCsvRepositoryTest()
        {
            Caminho = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AppData\\dados.csv");
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

