using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Motorista.Application.AutoMapper;
using Motorista.Application.Motorista.Queries.ListarMotoristas;
using Motorista.Domain.Enum;
using Motorista.Domain.Interfaces;
using NUnit.Framework;
using CarroModel = Motorista.Domain.Models.Carro;
using EnderecoModel = Motorista.Domain.Models.Endereco;
using MotoristaModel = Motorista.Domain.Models.Motorista;

namespace Tests.Application.Motorista.Queries
{
    public class ListarMotoristaQueryTests
    {
        private Mock<IMotoristaRepository> motoristaRepositoryMock;

        private IListarMotoristasQuery query;

        private MotoristaModel motorista;
        private MotoristaModel motorista2;
        
        private List<MotoristaModel> motoristas;

        private readonly string nomeMotorista = "Zé";

        private MapperConfiguration mapperConfiguration;

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

            motorista2 = new MotoristaModel {
                Id = 2,
                Nome = "Zé",
                UltimoNome = "Da Kombi",
                Carro = new CarroModel {
                    Id = 2,
                    Marca = "VW",
                    Modelo = "Kombi",
                    Placa = "ABC-1234"
                },
                Endereco = new EnderecoModel {
                    Id = 2,
                    CEP = "12345-000",
                    Cidade = "São Paulo",
                    Numero = 88,
                    Rua = "Av. Radial Leste",
                    UF = "SP"
                }
            };

            motoristas = new List<MotoristaModel> {
                motorista,
                motorista2
            };

            mapperConfiguration = AutoMapperConfig.RegisterMappings();

            var mockSet = new Mock<DbSet<MotoristaModel>>();
            mockSet.As<IQueryable<MotoristaModel>>().Setup(m => m.Provider).Returns(motoristas.AsQueryable().Provider);
            mockSet.As<IQueryable<MotoristaModel>>().Setup(m => m.Expression).Returns(motoristas.AsQueryable().Expression);
            mockSet.As<IQueryable<MotoristaModel>>().Setup(m => m.ElementType).Returns(motoristas.AsQueryable().ElementType);
            mockSet.As<IQueryable<MotoristaModel>>().Setup(m => m.GetEnumerator()).Returns(motoristas.AsQueryable().GetEnumerator());
            
            motoristaRepositoryMock = new Mock<IMotoristaRepository>();
            motoristaRepositoryMock
                .Setup(m => m.Listar(It.IsAny<Expression<Func<MotoristaModel, bool>>>()))
                .Returns(mockSet.Object);
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristas()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperConfiguration.CreateMapper());
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.Nenhum);

            restults.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristasOrdenadoPorNome()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperConfiguration.CreateMapper());
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.Nome);

            restults.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void TestExecuteDeveRetornarUmaListaDeMotoristasOrdenadoPorUltimoNome()
        {
            query = new ListarMotoristasQuery(motoristaRepositoryMock.Object, mapperConfiguration.CreateMapper());
            var restults = query.Execute(nomeMotorista, CampoOrdenacaoEnum.UltimoNome);

            restults.Should().NotBeNullOrEmpty();
        }
    }
}