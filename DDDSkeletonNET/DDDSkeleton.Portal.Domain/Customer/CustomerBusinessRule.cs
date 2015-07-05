using DDDSkeletonNET.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeleton.Portal.Domain.Customer
{
    [Obsolete("Use CustomerBusinessRulesMessages resource class instead.")]
    public static class CustomerBusinessRule
    {
        public static readonly BusinessRule CustomerNameRequired = new BusinessRule("A customer must have a name.");
    }
}
