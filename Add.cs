using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event_ q = new Event_(
                textBox1.Text,
                richTextBox1.Text,
                new DateTime(
                    dateTimePicker1.Value.Year,
                    dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day,
                Convert.ToInt32(numericUpDown1.Value),
                Convert.ToInt32(numericUpDown2.Value), 0));
            Event qq = new Event(q);
            Core.events.Add(qq);
            this.Close();
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
