using System.Data.Entity;

namespace Pseez.DataAccessLayer.IUnitOfWork
{
    public interface IUnitOfWorkSts
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}