using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PracticingDelagatesandEvent.StudentCard;

namespace PracticingDelagatesandEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            studentCard1.StudentSaved += studentCard1_StudentSaved;
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void studentCard1_StudentSaved(Student obj)
        {
            Student student = obj;
            listBox1.Items.Add(  student.Name + " - " + student.Age   );
        }
    }
}
