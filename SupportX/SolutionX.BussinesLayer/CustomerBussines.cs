using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionX.DataAccess;
using SolutionX.DomainEntities;

namespace SolutionX.BussinesLayer
{
    public class CustomerBussines
    {
        CustomerDataAcces customerData = new CustomerDataAcces();

        public Customer VerifyCustomer(Customer customer) {
            return customerData.VerifyUser(customer);
        }
        public Customer returnCustomer(Customer customer) {
            return customerData.ReturnValueCustomer(customer);
        }
        

}
}
