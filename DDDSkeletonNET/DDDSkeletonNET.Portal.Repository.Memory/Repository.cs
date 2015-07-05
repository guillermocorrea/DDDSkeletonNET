using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.Repository.Memory.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal.Repository.Memory
{
    /// <summary>
    /// Repository implementation.
    /// </summary>
    /// <typeparam name="DomainType">The type of the domain type.</typeparam>
    /// <typeparam name="IdType">The type of the id type.</typeparam>
    /// <typeparam name="DatabaseType">The type of the database type.</typeparam>
    public abstract class Repository<DomainType, IdType, DatabaseType> : IUnitOfWorkRepository where DomainType : IAggregateRoot
    {
        /// <summary>
        /// The _unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The _object context factory
        /// </summary>
        private readonly IObjectContextFactory _objectContextFactory;

        /// <summary>
        /// Gets the object context factory.
        /// </summary>
        /// <value>
        /// The object context factory.
        /// </value>
        public IObjectContextFactory ObjectContextFactory
        {
            get
            {
                return _objectContextFactory;
            }
        }

        /// <summary>
        /// Converts the type of to database.
        /// </summary>
        /// <param name="domainType">Type of the domain.</param>
        /// <returns></returns>
        public abstract DatabaseType ConvertToDatabaseType(DomainType domainType);

        /// <summary>
        /// Finds by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public abstract DomainType FindBy(IdType id);

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{DomainType, IdType, DatabaseType}" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="objectContextFactory">The object context factory.</param>
        /// <exception cref="System.ArgumentNullException">Unit of work
        /// or
        /// Object context factory</exception>
        public Repository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            if (objectContextFactory == null) throw new ArgumentNullException("Object context factory");
            _unitOfWork = unitOfWork;
            _objectContextFactory = objectContextFactory;
        }

        /// <summary>
        /// Persists the insertion.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        public void PersistInsertion(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().AddEntity<DatabaseType>(databaseType);
        }

        /// <summary>
        /// Persists the update.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        public void PersistUpdate(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().UpdateEntity<DatabaseType>(databaseType);
        }

        /// <summary>
        /// Persists the deletion.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        public void PersistDeletion(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().DeleteEntity<DatabaseType>(databaseType);
        }

        /// <summary>
        /// Updates the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        public void Update(DomainType aggregate)
        {
            _unitOfWork.RegisterUpdate(aggregate, this);
        }

        /// <summary>
        /// Inserts the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        public void Insert(DomainType aggregate)
        {
            _unitOfWork.RegisterInsertion(aggregate, this);
        }
        
        /// <summary>
        /// Deletes the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        public void Delete(DomainType aggregate)
        {
            _unitOfWork.RegisterDeletion(aggregate, this);
        }

        /// <summary>
        /// Retrieves the database type from.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <returns></returns>
        private DatabaseType RetrieveDatabaseTypeFrom(IAggregateRoot aggregateRoot)
        {
            DomainType domainType = (DomainType)aggregateRoot;
            DatabaseType databaseType = ConvertToDatabaseType(domainType);
            return databaseType;
        }
    }
}
