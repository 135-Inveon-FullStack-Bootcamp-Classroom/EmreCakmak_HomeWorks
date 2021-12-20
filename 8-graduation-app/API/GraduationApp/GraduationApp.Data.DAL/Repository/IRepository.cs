using GraduationApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Data.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetById(int Id);
        bool IsExists(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
        void Delete(TEntity entity);
    }
}
