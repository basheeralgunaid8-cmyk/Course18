using ContactsBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactWindowsForm
{
    public partial class frmAddEditContact : Form
    {
        public enum Mode { AddNewMode=0,UpdateMode=1};
        private Mode _Mode;

        int _ContactID;
        clsContacts _Contact;
        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (_ContactID == -1)
                _Mode = Mode.AddNewMode;
            else
                _Mode = Mode.UpdateMode;

        }

      
        private  void _FillAllcountrieInComobox()
        {
            DataTable dt = ClsCountries.GetAllCountries();

            foreach(DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"].ToString());
            }

        }

        private void _LoadData()
        {
            _FillAllcountrieInComobox();

            if (_Mode == Mode.AddNewMode)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContacts();
                return;
            }

            _Contact = clsContacts.Find(_ContactID);
            if (_Contact == null)
            {
                MessageBox.Show("Contact Not Found");
                this.Close();
                return;
            }

            lblMode.Text = "Edit Contact";
            lblContactID2.Text = _ContactID.ToString();
   
            txtFristName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtemail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            dtpBirthday.Value = _Contact.DateOfBirth;
            cbCountry.SelectedItem = cbCountry.FindString(ClsCountries.Find(_Contact.CountryID).CountryName);


        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int CountryID = ClsCountries.Find(cbCountry.Text).CountryID;

            _Contact.FirstName = txtFristName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtemail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtpBirthday.Value;
            _Contact.CountryID = CountryID;

            if (_Contact.Save())
                MessageBox.Show("Data saved successfully");
            else
                MessageBox.Show("Error : Data is not saved successfully");

            _Mode = Mode.UpdateMode;
            lblMode.Text = "Edit Contact ID =" + _Contact.ID;
            lblContactID1.Text = _Contact.ID.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Are You Sure To Close This Form?","Close Form",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            this.Close();
        }
    }
}
