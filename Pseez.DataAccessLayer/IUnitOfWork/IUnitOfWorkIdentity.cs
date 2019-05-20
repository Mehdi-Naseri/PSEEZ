using System.Data.Entity;

namespace Pseez.DataAccessLayer.IUnitOfWork
{
    public interface IUnitOfWorkIdentity
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}