using System;
using System.Collections.Generic;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt
{
    public interface _IGenericService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T Find(Func<T, bool> predicate);
        IList<T> GetAll();
        IList<T> GetAll(Func<T, bool> predicate);

        T FindById(int id);
        void DeleteById(int id);

        //void Update(T entity);
    }
}