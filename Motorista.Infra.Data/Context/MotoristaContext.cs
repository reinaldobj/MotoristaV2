using Microsoft.EntityFrameworkCore;
using Motorista.Domain.Models;

namespace Motorista.Infra.Data.Context
{
    public class MotoristaContext : DbContext
    {
        public MotoristaContext(DbContextOptions<MotoristaContext> options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Domain.Models.Motorista> Motoristas { get; set; }
    }
}
