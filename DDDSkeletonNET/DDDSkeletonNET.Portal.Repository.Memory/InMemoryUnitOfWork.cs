using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DDDSkeletonNET.Portal.Repository.Memory
{
    /// <summary>
    /// In memory unit of work implementation.
    /// </summary>
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Tracks the _inserted aggregates
        /// </summary>
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _insertedAggregates;
        /// <summary>
        /// Tracks the _updated aggregates
        /// </summary>
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _updatedAggregates;
        /// <summary>
        /// Tracks the _deleted aggregates
        /// </summary>
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _deletedAggregates;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryUnitOfWork"/> class.
        /// </summary>
        public InMemoryUnitOfWork()
        {
            _insertedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updatedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deletedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        /// <summary>
        /// Registers the update.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <param name="repository">The repository.</param>
        public void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_updatedAggregates.ContainsKey(aggregateRoot))
            {
                _updatedAggregates.Add(aggregateRoot, repository);
            }
        }

        /// <summary>
        /// Registers the insertion.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <param name="repository">The repository.</param>
        public void RegisterInsertion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_insertedAggregates.ContainsKey(aggregateRoot))
            {
                _insertedAggregates.Add(aggregateRoot, repository);
            }
        }

        /// <summary>
        /// Registers the deletion.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <param name="repository">The repository.</param>
        public void RegisterDeletion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_deletedAggregates.ContainsKey(aggregateRoot))
            {
                _deletedAggregates.Add(aggregateRoot, repository);
            }
        }

        /// <summary>
        /// Commits the transactions.
        /// </summary>
        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot aggregateRoot in _insertedAggregates.Keys)
                {
                    _insertedAggregates[aggregateRoot].PersistInsertion(aggregateRoot);
                }

                foreach (IAggregateRoot aggregateRoot in _updatedAggregates.Keys)
                {
                    _updatedAggregates[aggregateRoot].PersistUpdate(aggregateRoot);
                }

                foreach (IAggregateRoot aggregateRoot in _deletedAggregates.Keys)
                {
                    _deletedAggregates[aggregateRoot].PersistDeletion(aggregateRoot);
                }

                scope.Complete();
            }
        }
    }
}
