using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace AccountingApp {
    public partial class frmAddOrEditCustomer : Form {

        UnitOfWork db = new UnitOfWork();
        public int customerID = 0;
        public frmAddOrEditCustomer() {
            InitializeComponent();
        }

        private void btnSelectingPhoto_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK) {
                photoBox.ImageLocation = openFile.FileName;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e) {

        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (BaseValidator.IsFormValid(this.components)) {

                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(photoBox.ImageLocation);
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                photoBox.Image.Save(path + imageName);


                Customers customers = new Customers() {
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    FullName = txtName.Text,
                    Mobile = txtMobile.Text,
                    CustomerImage = "No photo.jpg"
                };

                if(customerID == 0) {
                    db.customerRepository.InsertCustomer(customers);
                } else {
                    customers.CustomerID = customerID;
                    db.customerRepository.UpdateCustomer(customers);
                }
                
                db.Save();
                DialogResult = DialogResult.OK;
            }
        }

        private void frmAddOrEditCustomer_Load(object sender, EventArgs e) {
            if(customerID!= 0) {
                this.Text = "Edit a client";
                btnSave.Text = "Edit";
                var customer = db.customerRepository.GetCustomerById(customerID);
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;
                txtMobile.Text = customer.Mobile;
                txtName.Text = customer.FullName;
                photoBox.ImageLocation = Application.StartupPath + "/Images/" + photoBox.Image;
            }
        }
    }
}
