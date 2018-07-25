using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CapptaApi.Constantes;
using CapptaApi.Models;
using CapptaApi.Repository;
using CapptaApi.Services;
using Moq;
using Xunit;

namespace XUnitTestCapptaAppi.Services
{
    public class TransacaoServiceTest
    {
        protected TransacaoService ServiceUnderTest { get; }
        protected Mock<ITransacaoRepository> transacaoRepositoryMock { get; }

        public TransacaoServiceTest()
        {
            transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            ServiceUnderTest = new TransacaoService(transacaoRepositoryMock.Object);
        }

        public class ConsultaPorCnpj : TransacaoServiceTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Cnpj()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });


                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorCnpj(""))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorCnpj("77404852000179");

                // Assert
                Assert.Same(listaTransicao, result);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_DataAtual_e_Mastercard()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179",
                    AcquirerAuthorizationDateTime = DateTime.Now,
                    CardBrandName = Const.Mastercard });               

                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorCnpjDataAtualMastercard("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorCnpjDataAtualMastercard("77404852000179");

                // Assert
                Assert.Same(listaTransicao, result);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_e_bandeira()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao
                {
                    MerchantCnpj = "77404852000179",
                    AcquirerAuthorizationDateTime = DateTime.Now,
                    CardBrandName = Const.Mastercard
                });

                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorCnpjEBandeira("77404852000179", Const.Mastercard))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorCnpjEBandeira("77404852000179", Const.Mastercard);

                // Assert
                Assert.Same(listaTransicao, result);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_Stone_Ultimos_30_Dias()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao
                {
                    MerchantCnpj = "77404852000179",
                    AcquirerAuthorizationDateTime = DateTime.Now,
                    CardBrandName = Const.Mastercard
                });

                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorCnpjStoneUltimos30Dias("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorCnpjStoneUltimos30Dias("77404852000179");

                // Assert
                Assert.Same(listaTransicao, result);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_Master_e_Vista()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao
                {
                    MerchantCnpj = "77404852000179",
                    AcquirerAuthorizationDateTime = DateTime.Now,
                    CardBrandName = Const.Mastercard
                });

                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorCnpjMasterEVisa("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorCnpjMasterEVisa("77404852000179");

                // Assert
                Assert.Same(listaTransicao, result);
            }
        }

        public class ConsultaPorAdquirente : TransacaoServiceTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Adquirente()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName= "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });


                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorAdquirente("Cielo", "Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorAdquirente("Cielo","Mastercard");

                // Assert
                Assert.Same(listaTransicao, result);
            }
        }

        public class ConsultaPorBandeira : TransacaoServiceTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Bandeira()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });


                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorBandeira("Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorBandeira("Mastercard");

                // Assert
                Assert.Same(listaTransicao, result);
            }
        }

        public class ConsultaPorData : TransacaoServiceTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Data_e_bandeira()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });


                transacaoRepositoryMock
                    .Setup(x => x.ConsultaPorAdquirente("Cielo", "Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ServiceUnderTest.ConsultaPorAdquirente("Cielo", "Mastercard");

                // Assert
                Assert.Same(listaTransicao, result);
            }
        }

    }
}
