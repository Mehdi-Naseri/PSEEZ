using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt;

namespace Pseez.ServiceLayer.EFServices.PseezEnt
{
    public class _EfGenericService<TEntity> : _IGenericService<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> _tEntities;
        protected IUnitOfWorkPseezEnt _uow;

        public _EfGenericService(IUnitOfWorkPseezEnt uow)
        {
            _uow = uow;
            _tEntities = _uow.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            _tEntities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _tEntities.Remove(entity);
        }

        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).FirstOrDefault();
        }

        public IList<TEntity> GetAll()
        {
            return _tEntities.ToList();
        }

        public IList<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).ToList();
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        //بخشهای تکمیلی
        public TEntity FindById(int id)
        {
            return _tEntities.Find(id);
        }

        public void DeleteById(int id)
        {
            var entity = _tEntities.Find(id);
            _tEntities.Remove(entity);
        }

        //}
        //    PseezEntContext.SaveChanges();
        //    PseezEntContext.Entry(entity).State = EntityState.Modified;
        //    Pseez.DataLayer.DataContext.PseezEntContext PseezEntContext = new DataLayer.DataContext.PseezEntContext();
        //{

        //public void Update(TEntity entity)
    }
}