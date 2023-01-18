using Accounting.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services {
    public class CustomerRepository : ICustomerRepository {

        private Accounting_DBEntities db;

        public CustomerRepository(Accounting_DBEntities context) {
            this.db = context;
        }

        public bool DeleteCustomer(int customerId) {

            try {
                var customer = GetCustomerById(customerId);
                DeleteCustomer(customer);
                return true;
            } catch {
                return false;
            }
        }

        public bool DeleteCustomer(Customers customer) {
            try {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            } catch {
                return false;
            }
        }

        public List<Customers> GetAllCustomers() {
            return db.Customers.ToList();
        }

        public IEnumerable<Customers> getCustomerByFilter(string filter) {
            return db.Customers.Where(c => c.FullName.Contains(filter) || c.Email.Contains(filter) || c.Mobile.Contains(filter)).ToList();
        }

        public Customers GetCustomerById(int customerId) {
            return db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer) {
            try {
                db.Customers.Add(customer);
                return true;
            } catch {
                return false;
            }
        }



        public bool UpdateCustomer(Customers customer) {
            //try {
            var local = db.Set<Customers>().Local
                .FirstOrDefault(f => f.CustomerID == customer.CustomerID);
            if (local != null) {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;
        }
    }
}
