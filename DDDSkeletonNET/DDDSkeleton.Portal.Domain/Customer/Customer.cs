using DDDSkeleton.Portal.Domain.ValueObjects;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public class Customer : EntityBase<int>, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address CustomerAddress { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddBrokenRule(new BusinessRule(CustomerBusinessRuleMessages.CustomerNameRequired));
            }

            CustomerAddress.ThrowExceptionIfInvalid();
        }
    }
}
