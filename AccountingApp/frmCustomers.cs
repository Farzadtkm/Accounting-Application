using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp {
    public partial class frmCustomers : Form {
        public frmCustomers() {
            InitializeComponent();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dgvCustomer.AutoGenerateColumns = false;

        }

        private void frmCustomers_Load(object sender, EventArgs e) {
            bindgrid();
        }

        void bindgrid() {
            using(UnitOfWork db = new UnitOfWork()) {
                dgvCustomer.DataSource = db.customerRepository.GetAllCustomers();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            txtSerch.Text = "";
            bindgrid();
        }

        private void txtSerch_Click(object sender, EventArgs e) {

        }

        private void txtSerch_TextChanged(object sender, EventArgs e) {
            using (UnitOfWork db = new UnitOfWork()) {
                dgvCustomer.DataSource = db.customerRepository.getCustomerByFilter(txtSerch.Text);  
            }
        }

        private void btnDeletePerson_Click(object sender, EventArgs e) {

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e) {
            frmAddOrEditCustomer frmAdd = new frmAddOrEditCustomer();
            if(frmAdd.ShowDialog()== DialogResult.OK){
                bindgrid();
            }
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e) {
            int customreId = int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString());
            frmAddOrEditCustomer frmedit = new frmAddOrEditCustomer();
            frmedit.customerID = customreId;
            if(frmedit.ShowDialog() == DialogResult.OK) {
                bindgrid();
            }
        }
    }
}
