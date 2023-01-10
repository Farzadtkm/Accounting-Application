﻿using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Context {
    public class UnitOfWork : IDisposable{

        Accounting_DBEntities db = new Accounting_DBEntities();
        private ICustomerRepository _customerRepository;

        public ICustomerRepository customerRepository {
            get {
                if(_customerRepository== null) {
                    _customerRepository = new CustomerRepository(db);
                }
                return _customerRepository;
            }
                
                
                }

        public void Dispose() {
            db.Dispose();
        }
    }
}
