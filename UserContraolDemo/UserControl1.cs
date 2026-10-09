using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserContraolDemo
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text;
            //lblName.Text = textBox1.Text;
            textBox2.Text = textBox2.Text;
            textBox3.Text = textBox3.Text;
            textBox4.Text = textBox4.Text;

            textBox5.Text = textBox5.Text;


        }
    }
}
