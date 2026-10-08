using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace PruebaConsola
{
	//todo deriva de System.Object (tiene 3 métodos que permiten sobregarga (toString, equals, getHash))
	public class Program
    {
        public static void Main(string[] args)
        {
            //todas las colecciones implementan la interfaz IEnumerable, que les provee capacidades comunes
            Song song = new Song();
            song.title = "Bajo la luna";
            song.seconds = 500;
            song.position = new ShelvePosition(0, 0);
            song.play();
            Console.ReadLine();

            Song song2 = new Song();
            song2.title = "Bajo la luna";
            song2.seconds = 350;
            song2.position = new ShelvePosition(1, 0);
            Console.WriteLine(song2.ToString());
            Console.ReadLine();
            //Console.WriteLine(typeof(int));
            //Console.ReadLine();

            //PlayList<Song> playlistSongs = new PlayList<Song>();
            //playlistSongs.add(song);
            //playlistSongs.add(song2);
            writeLineSpecial(song, "Start with", "enjoy");
            //las tuplas sirven para agrupar múltiples valores temporales (está bien cuando quieres retornar múltiples valores, se usan en consultas linq, en diccionarios donde la clave depende de dos valores...)
            Tuple<int, string, Song> tuple = new Tuple<int, string, Song>(0, "Hola", song);
			//Último elemento que entra, primero que sale (LIFO)
			stackExplanation();
			//Primero que entra, primero que sale (FIFO)
			queueExplanation();
			//es similar a los mapas en java (HashMap, que no guarda el orden de inserción)
			dictionaryExplanation();

            DownloadSong();
            new ReflectionSample();

        }

        private static void DownloadSong()
        {
            DownloadService downloadService=new DownloadService();
            byte[] song = downloadService.download("Bajo la luna");
        }
        private async static void downloadSongAsync()
        {
            DownloadService downloadService = new DownloadService();
            //downloadService.downloadAsync("Bajo la luna");
            byte[] futureSong = await downloadService.downloadAsync("Bajo la luna");

        }

		private static void dictionaryExplanation()
        {
           Dictionary<string,Client> clients=new Dictionary<string, Client>();
            clients.Add("12345678Q", new Client() { name = "Pepita" });
            if (!clients.ContainsKey("12345678Q")) {
                clients.Add("12345678Q", new Client() { name = "Pepita" }); 
            }
            clients["12345678Q"] = new Client();
            Client myClient = clients["12345678Q"];
            // busca de forma segura un valor asociado a una clave en un diccionario 
            // bool valor=clients.TryGetValue("12345678Q",out Client client);
            /*asi se recorrería un diccionario:
            foreach (KeyValuePair<string, Client> keyValue in clients)
            {

            }
            */
            var elements=new List<KeyValuePair<string,Client>>();
            elements.Add(new KeyValuePair<string, Client>("0001",new Client()));
			elements.Add(new KeyValuePair<string, Client>("0002", new Client()));
            //Utils.addRangeDictionary(clients, elements);
            Utils.addRange(clients,elements);
		}
		private static void queueExplanation()
        {
            Queue<int> queueNumbers = new Queue<int>();
            //agrega un item al final de la cola
            queueNumbers.Enqueue(1);
            //elimina el elemento del inicio, si la cola está vacía, excepción
            int number=queueNumbers.Dequeue();
        }

        private static void stackExplanation()
        {
          Stack<Song> salesSongs = new Stack<Song>();
            //para meter
            salesSongs.Push(new Song());
            //para sacar
            Song song = salesSongs.Pop();   
           
        }

        public static void writeLineSpecial<T>(T data, string prefix, string suffix) where T: Media
        {
            Console.WriteLine($"{prefix} {data.title} {suffix}");
        }
        public static void doSomethingWithMyClass<T>() where T : new()
        {
            Activator.CreateInstance<T>();
        }
        public static void sampleWithAtributtes()
        {
            {
                ReflectionSample sample = new ReflectionSample();
                MyAtributte atr = (MyAtributte)sample.GetType().GetCustomAttributes(false).FirstOrDefault();
                PropertyInfo[] properties = sample.GetType().GetProperties();
                properties[0].SetValue(sample, "Pepita");
                properties[0].GetValue(sample);
                MethodInfo[] methods=sample.GetType().GetMethods();
                MethodInfo doSomething=methods.FirstOrDefault(x => x.Name == "doSomething");
                if (doSomething != null)
                {
                    doSomething.Invoke(sample, null);
                }
                //similar a getProperty y propertyInfo
                sample.GetType().GetFields();
                Assembly.GetExecutingAssembly().GetManifestResourceNames();
            }

        }


	}
}

