using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repository {
    public interface ICustomerRepository {

        List<Customers> GetAllCustomers();
        Customers GetCustomerById(int customerId);

        IEnumerable<Customers> getCustomerByFilter(string filter);

        bool InsertCustomer(Customers customer);

        bool UpdateCustomer(Customers customer);

        bool DeleteCustomer(int customerId);

        bool DeleteCustomer(Customers customer);


    }
}
