using System.Data.Entity;

namespace Pseez.DataAccessLayer.IUnitOfWork
{
    public interface IUnitOfWorkPseezEnt
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}