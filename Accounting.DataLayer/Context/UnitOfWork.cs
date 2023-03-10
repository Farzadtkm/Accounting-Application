using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Context {
    public class UnitOfWork : IDisposable {

        Accounting_DBEntities db = new Accounting_DBEntities();
        private ICustomerRepository _customerRepository;

        public ICustomerRepository customerRepository {
            get {
                if (_customerRepository == null) {
                    _customerRepository = new CustomerRepository(db);
                }
                return _customerRepository;
            }


        }

        private GenericRepository<Accounting> _accountingRepository;


        public GenericRepository<Accounting> AccountingRepository {
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository=new GenericRepository<Accounting>(db);
                }

                return _accountingRepository;
            }
        
        }

        public void Save() {
            db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
