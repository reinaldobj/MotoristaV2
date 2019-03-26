using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MotoristaModel = Motorista.Domain.Models.Motorista;
using CarroModel = Motorista.Domain.Models.Carro;
using EnderecoModel = Motorista.Domain.Models.Endereco;
using Motorista.Domain.Interfaces;
using Motorista.Application.ViewModel;
using FluentAssertions;
using Motorista.Application.Motorista.Queries.ListarMotoristas;
using AutoMapper;
using Moq;
using System;
using System.Linq.Expressions;
using Motorista.Domain.Enum;

namespace Tests.Application.Motorista.Queries
{
    public class ListarMotoristaQueryTests
    {
        private Mock<IMapper> mapperMock;
        private Mock<IMotoristaRepository> motoristaRepositoryMock;

        private IListarMotoristasQuery query;

        private MotoristaModel motorista;
        private MotoristaViewModel motoristaViewModel;
        private string nomeMotorista = "Zé";

        [SetUp]
        public void SetUp()
        {
            motorista = new MotoristaModel {
                Id = 1,
                Nome = "Zé",
                UltimoNome = "Da Kombi",
                Carro = new CarroModel {
                    Id = 1,
                    Marca = "VW",
                    Modelo = "Kombi",
                    Placa = "ABC-1234"
                },
                Endereco = new EnderecoModel {
                    Id = 1,
                    CEP = "12345-000",
                    Cidade = "São Paulo",
                    Numero = 88,
                    Rua = "Av. Radial Leste",
                    UF = "SP"
                }
            };

            motoristaViewModel = new MotoristaViewModel {
                Id = 1,
                Nome = "Zé",
                UltimoNome = "Da Kombi",
                IdCarro = 1,
                Endereco = new EnderecoViewModel {
                    Id = 1,
                    CEP = "12345-000",
                    Cidade = "São Paulo",
                    Numero = 88,
                    Rua = "Av. Radial Leste",
                    UF = "SP"
                }
            };

            Predicate<MotoristaModel> predicate = 
                l => (string.IsNullOrEmpty(nomeMotorista) || l.Nome.Contains(nomeMotorista));

            motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            motoristaRepositoryMock
                .Setup(m => m.Listar(It.IsAny<Expression<Func<MotoristaModel, bool>>>()))
                .Returns(new List<MotoristaModel> { motorista }.AsQueryable());

            mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(m => m.Map<IEnumerable<MotoristaModel>, IEnumerable<MotoristaViewModel>>(new List<MotoristaModel> { motorista }))
                .Returns(new List<MotoristaViewModel> { motoristaViewModel }.AsQueryable());
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristas()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperMock.Object);
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.Nenhum);

            restults.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristasOrdenadoPorNome()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperMock.Object);
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.Nome);

            restults.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristasOrdenadoPorUltimoNome()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperMock.Object);
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.UltimoNome);

            restults.Should().NotBeNullOrEmpty();
        }
    }
}