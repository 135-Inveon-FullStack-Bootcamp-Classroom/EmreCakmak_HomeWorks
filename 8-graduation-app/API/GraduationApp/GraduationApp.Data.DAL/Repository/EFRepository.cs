using GraduationApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduationApp.Data.DAL.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationEFContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public EFRepository(ApplicationEFContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
           
        }

        public void Delete(int Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }
      

        public void Delete(TEntity entity)
        {
            _context.ChangeTracker.Clear();

            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
           
           // _context.Entry(entity).State= EntityState.Modified;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet;
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public bool IsExists(int id)
        {
            return _dbSet.Any(a => a.Id == id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
