using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Infrastructure.Common.Domain
{
    /// <summary>
    /// Read only repository.
    /// </summary>
    /// <typeparam name="AggregateType">The type of the aggregate type.</typeparam>
    /// <typeparam name="IdType">The type of the id type.</typeparam>
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        /// <summary>
        /// Finds by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        AggregateType FindBy(IdType id);
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AggregateType> FindAll();
    }
}