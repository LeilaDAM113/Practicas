using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola2
{
    public class PlayList<T>
    {
        List<T> medialist=new List<T>();
        public void add(T media)
        {
            list.Add(media);
        }
        public void playAll()
        {
            foreach (T media in list)
            {
                Console.WriteLine(media);
            }
        }
        public void preview()
        {
            if (medialist.Count > 0)
            {
                Console.WriteLine(medialist [0]);
            }
        }
    }
}
