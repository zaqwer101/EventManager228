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
    //Логика событий
    public class Event
    {
        public Timer timer;
        public Event_ event_;



        /*********************************************************/
        public delegate void EventHappensHandler(object sender, object msg);
        public event EventHappensHandler Happen;
        /*********************************************************/
        public Event(Event_ event_)
        {
            this.event_ = event_;
            this.timer = new Timer();
            this.timer.Interval = 100;
            timer.Start();
            timer.Tick += timer_Tick;
            this.Happen += new Event.EventHappensHandler(q_Happen);
        }

        private void q_Happen(object sender, object msg)
        {
            Core.Update_list();
            Core.SyncList(Core.form1.listBox1);
            MessageBox.Show((String)msg);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            /*********************************************************/
            if (DateTime.Now.CompareTo(this.event_.time) > 0 && !this.event_.signaled)
            {
                this.event_.signaled = true;
                ((Timer)sender).Stop();
                this.Happen(this, "Событие " + this.event_.name + " наступило");
            }
            /*********************************************************/
        }
    }
}
