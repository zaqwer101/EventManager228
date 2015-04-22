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
    public static class Core
    {
        public static List<Event> events = new List<Event>();

        public static void Set_Events()
        {
            for(int i=0;i<events.Count;i++)
            {
                events[i].Checker += (DateTime x) => 
                {
                    if(x == DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                events[i].Happened += Core_Happened;
            }
        }

        static void Core_Happened()
        {
            MessageBox.Show("Что-то произошло");            
        }



        public static void Update_list()
        {
            for(int i=0;i<events.Count;i++)
            {
                for(int f=i+1;f<events.Count;f++)
                {
                    if (events[f].time.Ticks < events[i].time.Ticks)
                    {
                        var temp = events[i];
                        events[i] = events[f];
                        events[f] = temp;
                    }
                }
            }
        }

        
    }
}
