using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Infrastructure.Common.Domain
{
    /// <summary>
    /// Repository component.
    /// </summary>
    /// <typeparam name="AggregateType">The type of the aggregate type.</typeparam>
    /// <typeparam name="IdType">The type of the id type.</typeparam>
    public interface IRepository<AggregateType, IdType>
        : IReadOnlyRepository<AggregateType, IdType> where AggregateType
        : IAggregateRoot
    {
        /// <summary>
        /// Updates the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        void Update(AggregateType aggregate);
        /// <summary>
        /// Inserts the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        void Insert(AggregateType aggregate);
        /// <summary>
        /// Deletes the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        void Delete(AggregateType aggregate);
    }
}
