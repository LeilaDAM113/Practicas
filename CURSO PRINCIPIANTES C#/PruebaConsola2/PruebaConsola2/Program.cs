using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaConsola;

namespace PruebaConsola2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Song song = new Song();
            song.title = "Bajo la luna";
            song.seconds = 500;
            song.position=new ShelvePosition(0,0);

            Song song2=new Song();
            song2.title = "Bajo la luna";
            song2.seconds = 350;
            song2.position = new ShelvePosition(1, 0);
            PlayList<Song> playListSongs=new PlayList<Song>(); 
            playListSongs.add(song);
            playListSongs.add(song2);
            writeLineSpecial<Song>(song, "Start with", "enjoy");
            Console.WriteLine(song2.ToString());
            Console.ReadLine();
       
        }
		public static void writeLineSpecial<T>(T data, string prefix, string suffix) where T : Media
		{
			Console.WriteLine($"{prefix} {data.title} {suffix}");
		}
	}
}
