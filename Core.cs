using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public static class Core
    {
        public static FileStream fs;
        public static Form1 form1;
        public static List<Event> events = new List<Event>();

        public static List<Event> signaled_events = new List<Event>(); // --> список просроченых событий
        public static void Update_list()
        {
            //Цикл, проверяющий, просрочено ли событие
            for (int i = 0; i < events.Count;i++)
            {
                if (events[i].event_.signaled)
                {
                    events[i].event_.name = '*' + events[i].event_.name;
                    signaled_events.Add(events[i]);
                    events.RemoveAt(i);
                }
            }
           //Сортировка
           for (int i = 0; i < events.Count; i++)
           {
                    for (int f = i + 1; f < events.Count; f++)
                {
                    if (events[f].event_.time.Ticks < events[i].event_.time.Ticks)
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
                listBox.Items.Add(Core.events[i].event_.name);
            }
        }
        //Сериализация и сохранение в файл
        public static void Serial()
        {
            fs = new FileStream("qq.dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs, 
                (Event_[])((
                from x in Core.events
                select x.event_).ToArray())
                );
            fs.Close();
        }
        //Десериализация и заполнение списка событий
        public static void DeSerial()
        {
            try
            {
                fs = new FileStream("qq.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Event_[] temp_ = (Event_[])binaryFormatter.Deserialize(fs);
                events.Clear();
                var temp__ = temp_.Cast<Event_>().ToList();
                for (int i = 0; i < temp__.Count; i++)
                {
                    events.Add(new Event(temp__[i]));
                }
                Update_list();
                SyncList(form1.listBox1);
                fs.Close();
            }
            catch
            {

            }
        }
        
    }
}
