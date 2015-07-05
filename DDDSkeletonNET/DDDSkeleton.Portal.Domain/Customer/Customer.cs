using DDDSkeletonNET.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public class Customer : EntityBase<int>
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
