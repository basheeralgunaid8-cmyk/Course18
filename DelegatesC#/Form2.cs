using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesC_
{
    public partial class Form2 : Form
    {

        public delegate void DataBackEventHandler(object sender, Color myColor);

        public event DataBackEventHandler DataBack;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Color myColor = Color.Red;

            DataBack?.Invoke(this, myColor);

            this.Close();

        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            Color myColor = Color.Green;

            DataBack?.Invoke(this, myColor);

            this.Close();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            Color myColor = Color.Blue;

            DataBack?.Invoke(this, myColor);

            this.Close();
        }
    }
}
