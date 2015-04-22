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

        public delegate bool Handler_Checker(DateTime x);
        public event Handler_Checker Checker;
        public delegate void Handler_Happend();
        public event Handler_Happend Happened;
        public DateTime time;
        public string name, text;
        public bool happend;
        public Event(string name, string text, DateTime time)
        {
            this.name = name;
            this.text = text;
            this.time = time;
            this.timer = new Timer();
            this.timer.Interval = 100;
            timer.Start();
            timer.Tick += timer_Tick;
            this.Checker += (DateTime x) => { return false; };
            this.Happened += () => { };
            this.happend = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if(Checker(this.time))
            {
                Happened();
            }
        }
    }
}
