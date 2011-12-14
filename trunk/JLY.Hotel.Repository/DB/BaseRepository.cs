using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JLY.Hotel.Repository.DB
{
     using System.Collections;

     using JLY.Hotel.Model.Entities;

     public class BaseRepository : IRepository
    {
        private DbContext context;

        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(this.context);
                }
                return unitOfWork;
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public BaseRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.SetInitialaizerData();
            this.context = context;
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Context.Set<TEntity>().Single(criteria);
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            return Context.Set<TEntity>().IncludeMultiple(includes).Single(criteria);
        }

        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return Context.Set<TEntity>().First(predicate);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IEnumerable<TEntity> records = Find<TEntity>(criteria);

            foreach (TEntity record in records)
            {
                Delete<TEntity>(record);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        { }

        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Context.Set<TEntity>().Where(criteria);
        }

        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            return Context.Set<TEntity>().IncludeMultiple(includes).Where(criteria);
        }

        public TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Context.Set<TEntity>().Where(criteria).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return Context.Set<TEntity>().OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
            }
            return Context.Set<TEntity>().OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder) where TEntity : class
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return Context.Set<TEntity>().Where(criteria).OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
            }
            return Context.Set<TEntity>().Where(criteria).OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
        }

        public int Count<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().Count();
        }

        public int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            try
            {
                return Context.Set<TEntity>().Where(criteria).Count();
            }
            catch (DataException e)
            {
                var ex = (DbEntityValidationException)e.InnerException;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return 0;
        }


        private void SetInitialaizerData()
        {
             System.Data.Entity.Database.SetInitializer(new HotelDBInitializer());
        }

    }

    public class HotelDBInitializer : DropCreateDatabaseIfModelChanges<HotelDB>
    {
         protected override void Seed(HotelDB context)
         {
              base.Seed(context);

              context.Users.Add(new User() { Name = "Luciano", });
              context.Users.Add(new User() { Name = "Juan Jose", });
              context.Users.Add(new User() { Name = "Chango", });
              context.SaveChanges();
         }
    }


}
