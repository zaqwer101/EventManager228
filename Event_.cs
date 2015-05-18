using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
//Информация о событии
[Serializable]
    public class Event_
    {
        public bool signaled = false;
        public DateTime time;
        public string name, text;
        public Event_(string name,string text, DateTime time )
        {
            this.name = name;
            this.text = text;
            this.time = time;
        }
    }
}
