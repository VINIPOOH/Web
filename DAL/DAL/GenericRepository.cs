﻿using ComputerNet.DAL.Interfaces;
using ComputerNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 using Microsoft.EntityFrameworkCore;
 using WebApplication1.Dal;

 namespace ComputerNet.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(MyDbContext context)
        {            
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
