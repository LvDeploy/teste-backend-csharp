using System;
using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.TorreHanoi;
using System.Collections.Generic;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class TorreHanoiUnit
    {
        private const string CategoriaTeste = "Domain/TorreHanoi";

        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(s => s.Logar(It.IsAny<string>(), It.IsAny<TipoLog>()));
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Construtor_Deve_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3,_mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.AreEqual(torre.Status, TipoStatus.Pendente);
            Assert.AreNotEqual(torre.Id, new Guid());
            Assert.IsNotNull(torre.Destino);
            Assert.IsNotNull(torre.Intermediario);
            Assert.IsNotNull(torre.Origem);
            Assert.AreNotEqual(torre.DataCriacao, new DateTime());
            Assert.AreEqual(torre.PassoAPasso.Count, 0);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Processar_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            torre.Processar();

            Assert.AreEqual(torre.Status, TipoStatus.FinalizadoSucesso);
        }
    }
}
