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
    public partial class Form1 : Form
    {
        public void UpdateList()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(Core.events.ToArray());
        }

        public Form1()
        {
            InitializeComponent();
            
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Core.DeSerial();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.richTextBox1.Text = Core.events[listBox1.SelectedIndex].event_.name + "\n" + Core.events[listBox1.SelectedIndex].event_.time.ToString() + "\n-----------------\n" + Core.events[listBox1.SelectedIndex].event_.text;
            }
            catch { }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            Core.Update_list();
            Core.SyncList(this.listBox1);
        }



        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void событиеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void прошедшиеСобытияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void дополнительноToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.Serial();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {

        }
    }
}
