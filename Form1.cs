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
        //Синхронизировать листбокс со списком событий
        void SyncList()
        {
            this.listBox1.Items.Clear();
            
            for(int i=0;i<Core.events.Count;i++)
            {
                this.listBox1.Items.Add(Core.events[i].name);
            }
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.richTextBox1.Text = Core.events[listBox1.SelectedIndex].name + "\n" + Core.events[listBox1.SelectedIndex].time.ToString() + "\n-----------------\n" + Core.events[listBox1.SelectedIndex].text;
            }
            catch { }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            Core.Update_list();
            SyncList();
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
    }
}
