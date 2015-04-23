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
    public class Event
    {
        private Timer timer;


        public DateTime time;
        public string name, text;

        /*********************************************************/
        public delegate void EventHappensHandler(object sender, object msg);
        public event EventHappensHandler Happen;
        public bool signaled = false;
        /*********************************************************/
        public Event(string name, string text, DateTime time)
        {
            this.name = name;
            this.text = text;
            this.time = time;
            this.timer = new Timer();
            this.timer.Interval = 100;
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            /*********************************************************/
            if (DateTime.Now.CompareTo(time)>0 && !signaled)
            {
                signaled = true;
                ((Timer)sender).Stop();
                Happen(this, "Событие " +name+ " наступило");
            }
            /*********************************************************/
        }
    }
}
