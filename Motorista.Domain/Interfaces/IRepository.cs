using System;
using System.Linq;
using System.Linq.Expressions;

namespace Motorista.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IQueryable<TEntity> ListarTodos();
        IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate);
        void Atualizar(TEntity obj);
        void Excluir(int id);
        int SalvarAlteracoes();
    }
}
