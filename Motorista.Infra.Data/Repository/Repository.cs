using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Motorista.Domain.Interfaces;
using Motorista.Infra.Data.Context;

namespace Motorista.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MotoristaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MotoristaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity ObterPorId(int id)
        {
            var obj = DbSet.Find(id);
            Db.Entry(obj).State = EntityState.Detached;

            return obj;
        }

        public virtual IQueryable<TEntity> ListarTodos()
        {
            return DbSet;
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }


        public int SalvarAlteracoes()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Excluir(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
