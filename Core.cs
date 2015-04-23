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
        public static List<Event> signaled_events = new List<Event>(); // --> список просроченых событий
        public static void Update_list()
        {
            //Цикл, проверяющий, просрочено ли событие
            for (int i = 0; i < events.Count;i++)
            {
                if(events[i].signaled)
                {
                    events[i].name = '*' + events[i].name;
                    signaled_events.Add(events[i]);
                    events.RemoveAt(i);
                }
            }
           //Сортировка
           for (int i = 0; i < events.Count; i++)
           {
                    for (int f = i + 1; f < events.Count; f++)
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

        //Синхронизировать листбокс со списком событий
        public static void SyncList(ListBox listBox)
        {
            listBox.Items.Clear();

            for (int i = 0; i < Core.events.Count; i++)
            {
                listBox.Items.Add(Core.events[i].name);
            }
        }

        
    }
}
