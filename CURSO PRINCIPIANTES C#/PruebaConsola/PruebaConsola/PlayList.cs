using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{ 
    public class PlayList<T> where T : Song
    {
        // public class PlayList
        // {
        List<T> mediaList=new List<T>();
		//List<Song> mediaList = new List<Song>();
		//usando genéricos (tienes que especificar el tipo de dato que usas entre los operadores diamond)
		//public class PlayList<T>
		//{
		/*
        T[] medialist = new T[] { };
        public void add(T media)
        {
            for (int i = 0; i < medialist.Length; i++)
            {
                medialist[i] = media;
            }
        }
        public void playAll()
        {
            foreach (T media in medialist)
            {
                Console.WriteLine(media); 
            }
        }
         */
		/*ArrayList list = new ArrayList();
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
            if (list.Count > 0)
            {
                T media = (T)list[0];
            }
        }*/
		//      List<T> medialist = new List<T>();
		//public void add(T media)
		//{
		//	medialist.Add(media);
		//}
		//public void playAll()
		//{
		//	foreach (T media in medialist)
		//	{
		//		Console.WriteLine(media);
		//	}
		//}
		//public void preview()
		//{
		//	if (medialist.Count > 0)
		//	{
		//              Console.WriteLine(medialist[0]);
		//	}
		//}

		public List<T> searchCategory(string category)
        {

			/*List<Song> songs = new List<Song>();
            foreach (Song song in mediaList)
            {
                if (song.category == category)
                {
                    songs.Add(song);
                }
            }
            return songs;
            */
			return mediaList.Where(x => x.category == category).ToList();

		}
		public List<T> searchTitle(string title)
        {
            return mediaList.Where(x => x.title.Contains(title)).ToList();
           /* List<Song> songs = new List<Song>();
            foreach (Song song in mediaList)
            {
                if (song.title.Contains(title))
                {
                    songs.Add(song);
                }
            }
            return songs;
           */
        }

        public List<string> gimmeTitlesFromSongs()
        {
            return mediaList.Select(x => x.title).ToList();
            //mediaList.Select(x=> new Tuple <string, string>(x.title,x.category)).ToList();
            /*List<string> titles = new List<string>();
            foreach (Song song in mediaList)
            {
                titles.Add(song.title);
            }
            return titles;
            */
        }
        public List<string> gimmeNamesOfArtist()
        {
            return mediaList.SelectMany(x => x.artists).Select(x => x.name).ToList();
        }
        public bool haveATitle(string title)
        {
            return mediaList.Any(x => x.title == title);
        }
        public Song getFirstSongWithLess1Minute()
        {
            var song = mediaList.FirstOrDefault(x => x.seconds < 60);
            if (song != null)
            {
                return song;
            }
            else
            {
                Console.WriteLine("Error, no hay ninguna cancion con menos de 60 s.");
                return null;
            }

        }
		public Song getLastSongWithLess1Minute()
		{
			var song = mediaList.LastOrDefault(x => x.seconds < 60);
			if (song != null)
			{
				return song;
			}
			else
			{
				Console.WriteLine("Error, no hay ninguna cancion con menos de 60 s.");
				return null;
			}

		}
        public List<T> top10()
        {
            return mediaList.OrderBy(x => x.visits).ToList();
           // return mediaList.Take(10).ToList();

        }
			 public List<T> skip10top20()
		{
			return mediaList.Skip(10).Take(10).ToList();
		}
        public List<T> bottom10()
        {
         return mediaList.OrderByDescending(x => x.visits).Take(10).ToList();
        }
		public T[] bottom10Array()
		{
			return mediaList.OrderByDescending(x => x.visits).Take(10).ToArray();
		}
		public void groupFromCategory()
        {
            mediaList.GroupBy(x => x.category).ToDictionary(x => x.Key);
        }
        public List<Media> toConvertMedia()
        {
           return mediaList.OfType<Media>().ToList();
        }
		public void add(T media)
		{
			mediaList.Add(media);
		}
		public void playAll()
		{
            
			foreach (T media in mediaList)
			{
				Console.WriteLine(media);
			}
		}
        
       
	}
}
