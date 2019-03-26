using Motorista.Domain.Interfaces;
using Motorista.Infra.Data.Context;

namespace Motorista.Infra.Data.Repository
{
    public class CarroRepository : Repository<Domain.Models.Carro>, ICarroRepository
    {
        public CarroRepository(MotoristaContext context) : base(context)
        {
        }
    }
}
