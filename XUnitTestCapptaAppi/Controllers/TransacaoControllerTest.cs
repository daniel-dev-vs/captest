using CapptaApi.Constantes;
using CapptaApi.Controllers;
using CapptaApi.Models;
using CapptaApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestCapptaAppi.Controllers
{
    public class TransacaoControllerTest
    {
        protected TransacaoController ControllerUnderTest { get; }
        protected Mock<ITransacaoService> transacaoServiceMock { get; }

        public TransacaoControllerTest()
        {
            transacaoServiceMock = new Mock<ITransacaoService>();
            ControllerUnderTest = new TransacaoController(transacaoServiceMock.Object);
        }

        public class ConsultaPorCnpj : TransacaoControllerTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Cnpj()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179" });


                transacaoServiceMock
                    .Setup(x => x.ConsultaPorCnpj("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorCnpj("77404852000179");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
            }

            [Fact]
            public async Task Deve_Consultar_Por_Cnpj_DataAtual_e_Mastercard()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao
                {
                    MerchantCnpj = "77404852000179",
                    AcquirerAuthorizationDateTime = DateTime.Now,
                    CardBrandName = Const.Mastercard
                });

                transacaoServiceMock
                    .Setup(x => x.ConsultaPorCnpjDataAtualMastercard("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorCnpjDataAtualMastercard("77404852000179");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
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

                transacaoServiceMock
                    .Setup(x => x.ConsultaPorCnpjEBandeira("77404852000179", Const.Mastercard))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorCnpjEBandeira("77404852000179", Const.Mastercard);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
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

                transacaoServiceMock
                    .Setup(x => x.ConsultaPorCnpjStoneUltimos30Dias("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorCnpjStoneUltimos30Dias("77404852000179");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
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

                transacaoServiceMock
                    .Setup(x => x.ConsultaPorCnpjMasterEVisa("77404852000179"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorCnpjMasterEVisa("77404852000179");

                // Assert
                Assert.Same(listaTransicao, result);
            }
        }

        public class ConsultaPorAdquirente : TransacaoControllerTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Adquirente()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });


                transacaoServiceMock
                    .Setup(x => x.ConsultaPorAdquirente("Cielo", "Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorAdquirente("Cielo", "Mastercard");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
            }
        }

        public class ConsultaPorBandeira : TransacaoControllerTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Bandeira()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard" });


                transacaoServiceMock
                    .Setup(x => x.ConsultaPorBandeira("Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorBandeira("Mastercard");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
            }
        }

        public class ConsultaPorData : TransacaoControllerTest
        {
            [Fact]
            public async Task Deve_Consultar_Por_Data_e_bandeira()
            {
                // Arrange

                var listaTransicao = new List<Transacao>();
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });
                listaTransicao.Add(new Transacao { MerchantCnpj = "77404852000179", AcquirerName = "Cielo", CardBrandName = "MasterCard", AcquirerAuthorizationDateTime = DateTime.Now });


                transacaoServiceMock
                    .Setup(x => x.ConsultaPorAdquirente("Cielo", "Mastercard"))
                    .ReturnsAsync(listaTransicao);

                // Act
                var result = await ControllerUnderTest.ConsultaPorAdquirente("Cielo", "Mastercard");

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(listaTransicao, okResult.Value);
            }
        }
    }
}
