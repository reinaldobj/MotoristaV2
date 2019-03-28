using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Motorista.Domain.Interfaces;
using Motorista.Infra.Data.Context;

namespace Motorista.Infra.Data.Repository
{
    public class MotoristaRepository : Repository<Domain.Models.Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(MotoristaContext context) : base(context)
        {
        }

        public override IQueryable<Domain.Models.Motorista> Listar(Expression<Func<Domain.Models.Motorista, bool>> predicate)
        {
            return DbSet
                .Where(predicate)
                .Include(m => m.Carro)
                .Include(m => m.Endereco);
        }

        public override Domain.Models.Motorista ObterPorId(int id)
        {
            return DbSet
                .Include(m => m.Carro)
                .Include(m => m.Endereco)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
