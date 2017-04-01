//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using WebApplication.Infrastructure.Interface;

//namespace WebApplication.Infrastructure.Repository
//{
//    public abstract class AbstractBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
//    {

//        internal ApplicationDbContext _context;
//        private readonly IUnitOfWork _unitOfWork;

//        protected AbstractBaseRepository(IUnitOfWork unitOfWork)
//        {
//            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
//            _unitOfWork = unitOfWork;

//            _context = _unitOfWork.DbContext;
//        }

//        public TEntity GetByKey(object keyValue)
//        {
//            EntityKey key = GetEntityKey(keyValue);

//            object originalItem;
//            if (((IObjectContextAdapter)_context).ObjectContext.TryGetObjectByKey(key, out originalItem))
//            {
//                return (TEntity)originalItem;
//            }
//            return default(TEntity);
//        }

//        public IQueryable<TEntity> GetQuery()
//        {
//            var entityName = GetEntityName();
//            return ((IObjectContextAdapter)_context).ObjectContext.CreateQuery<TEntity>(entityName);
//        }

//        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
//        {
//            return GetQuery().Where(predicate);
//        }

//        public IQueryable<TEntity> GetQuery(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntitiesFrom(GetQuery());
//        }

//        public IEnumerable<TEntity> Get<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
//        {
//            if (sortOrder == SortOrder.Ascending)
//            {
//                return GetQuery().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//            }
//            return GetQuery().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//        }

//        public IEnumerable<TEntity> Get<TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
//        {
//            if (sortOrder == SortOrder.Ascending)
//            {
//                return GetQuery(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//            }
//            return GetQuery(criteria).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//        }

//        public IEnumerable<TEntity> Get<TOrderBy>(ISpecification<TEntity> specification, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending)
//        {
//            if (sortOrder == SortOrder.Ascending)
//            {
//                return specification.SatisfyingEntitiesFrom(GetQuery()).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//            }
//            return specification.SatisfyingEntitiesFrom(GetQuery()).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
//        }

//        public TEntity Single(Expression<Func<TEntity, bool>> criteria)
//        {
//            var rec = GetQuery();

//            if (rec == null) throw new EntityNotFoundException<TEntity>(criteria);

//            return rec.Single(criteria);
//        }

//        public TEntity Single(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntityFrom(GetQuery());
//        }

//        public TEntity GetBy(Expression<Func<TEntity, bool>> predicate)
//        {
//            var rec = GetQuery();

//            if (rec == null) throw new EntityNotFoundException<TEntity>(predicate);

//            return rec.FirstOrDefault(predicate);
//        }

//        public TEntity GetBy(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntitiesFrom(GetQuery()).First();
//        }

//        public void Add(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            _context.Set<TEntity>().Add(entity);
//            _unitOfWork.SaveChanges();
//        }

//        public void Attach(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }

//            _context.Set<TEntity>().Attach(entity);
//        }

//        public void Delete(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            _context.Set<TEntity>().Remove(entity);
//            _unitOfWork.SaveChanges();
//        }

//        public void Delete(Expression<Func<TEntity, bool>> criteria)
//        {
//            IEnumerable<TEntity> records = Find(criteria);

//            foreach (var record in records)
//            {
//                Delete(record);
//            }
//        }

//        public void Delete(ISpecification<TEntity> criteria)
//        {
//            IEnumerable<TEntity> records = Find(criteria);
//            foreach (var record in records)
//            {
//                Delete(record);
//            }
//        }

//        public IEnumerable<TEntity> GetAll()
//        {
//            return GetQuery().AsEnumerable();
//        }

//        public TEntity Save(TEntity entity)
//        {
//            Add(entity);
//            _unitOfWork.SaveChanges();
//            return entity;
//        }

//        public void Update(TEntity entity)
//        {
//            var fqen = GetEntityName();

//            object originalItem;
//            var key = ((IObjectContextAdapter)_context).ObjectContext.CreateEntityKey(fqen, entity);
//            if (((IObjectContextAdapter)_context).ObjectContext.TryGetObjectByKey(key, out originalItem))
//            {
//                ((IObjectContextAdapter)_context).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
//                _unitOfWork.SaveChanges();
//            }
//        }

//        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
//        {
//            return GetQuery().Where(criteria);
//        }

//        public TEntity FindOne(Expression<Func<TEntity, bool>> criteria)
//        {
//            var rec = GetQuery();

//            if (rec == null) throw new EntityNotFoundException<TEntity>(criteria);

//            return rec.Where(criteria).FirstOrDefault();
//        }

//        public TEntity FindOne(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntityFrom(GetQuery());
//        }

//        public IEnumerable<TEntity> Find(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntitiesFrom(GetQuery()).AsEnumerable();
//        }

//        public int Count()
//        {
//            return GetQuery().Count();
//        }

//        public int Count(Expression<Func<TEntity, bool>> criteria)
//        {
//            var rec = GetQuery();

//            if (rec == null) throw new EntityNotFoundException<TEntity>(criteria);

//            return rec.Count(criteria);
//        }

//        public int Count(ISpecification<TEntity> criteria)
//        {
//            return criteria.SatisfyingEntitiesFrom(GetQuery()).Count();
//        }

//        private EntityKey GetEntityKey(object keyValue)
//        {
//            var entitySetName = GetEntityName();
//            var objectSet = ((IObjectContextAdapter)_context).ObjectContext.CreateObjectSet<TEntity>();
//            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
//            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
//            return entityKey;
//        }

//        private string GetEntityName()
//        {
//            // PluralizationService pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
//            // return string.Format("{0}.{1}", ((IObjectContextAdapter)_context).ObjectContext.DefaultContainerName, pluralizer.Pluralize(typeof(TEntity).Name));

//            // Thanks to Kamyar Paykhan -  http://huyrua.wordpress.com/2011/04/13/entity-framework-4-poco-repository-and-specification-pattern-upgraded-to-ef-4-1/#comment-688
//            string entitySetName = ((IObjectContextAdapter)_context).ObjectContext
//                .MetadataWorkspace
//                .GetEntityContainer(((IObjectContextAdapter)_context).ObjectContext.DefaultContainerName, DataSpace.CSpace)
//                .BaseEntitySets.First(bes => bes.ElementType.Name == typeof(TEntity).Name).Name;
//            return string.Format("{0}.{1}", ((IObjectContextAdapter)_context).ObjectContext.DefaultContainerName, entitySetName);
//        }

//        public void Dispose()
//        {
//            if (_log.IsDebugEnabled)
//            {
//                _log.DebugFormat("Disposing absract base repository....{0}", typeof(TEntity));
//            }

//            if (_unitOfWork.DbContext != null)
//            {
//                _unitOfWork.DbContext.Dispose();
//            }

//            _unitOfWork.Dispose();
//        }
//    }
//}
