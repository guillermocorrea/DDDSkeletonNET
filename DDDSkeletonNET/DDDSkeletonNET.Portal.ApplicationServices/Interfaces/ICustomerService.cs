﻿using DDDSkeletonNET.Portal.ApplicationServices.Messaging.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal.ApplicationServices.Interfaces
{
    public interface ICustomerService
    {
        GetCustomerResponse GetCustomer(GetCustomerRequest getCustomerRequest);
        GetCustomersResponse GetAllCustomers();
        InsertCustomerResponse InsertCustomer(InsertCustomerRequest insertCustomerRequest);
        UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest updateCustomerRequest);
        DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest deleteCustomerRequest);
    }
}
