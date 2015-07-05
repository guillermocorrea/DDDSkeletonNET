using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers
{
    public class DeleteCustomerRequest : IntegerIdRequest
    {
        public DeleteCustomerRequest(int customerId)
            : base(customerId)
        { }
    }
}
