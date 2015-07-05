using DDDSkeletonNET.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
