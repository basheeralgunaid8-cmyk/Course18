using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticingDelagatesandEvent
{
    public partial class StudentCard : UserControl
    {

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }

        }

        public event Action<Student> StudentSaved;

        public StudentCard()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student.Name = textBox1.Text;
            student.Age = (int)numericUpDown1.Value;

            StudentSaved?.Invoke(student);
        }
    }
}
