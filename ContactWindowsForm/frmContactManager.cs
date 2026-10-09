using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBussinessLayer;
namespace ContactWindowsForm
{
    public partial class FrmContactManager : Form
    {
        public FrmContactManager()
        {
            InitializeComponent();
         
        }

      private void _RefrishAllContacts()
        {
            dgvAllContacts.DataSource = clsContacts.GetAllContacts();
            dgvAllContacts.ColumnHeadersVisible = false;
        }

        private void FrmContactManager_Load(object sender,EventArgs e)
        {
            _RefrishAllContacts();

        }

        private void _EditContact()
        {
            frmAddEditContact frm = new frmAddEditContact(Convert.ToInt32(dgvAllContacts.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefrishAllContacts();
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            _EditContact();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure To Delete This Contact?","Delete Contact",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                clsContacts.DeleteContact(Convert.ToInt32(dgvAllContacts.CurrentRow.Cells[0].Value));
                MessageBox.Show("Contact Deleted Successfully","Delete Contact",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _RefrishAllContacts();
            }
            else
                            {
                MessageBox.Show("Contact Not Deleted","Delete Contact",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefrishAllContacts();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _EditContact();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }

}
