using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{
    public static class Utils
    {
        //add range sirve para añadir un conjunto de elementos a una colección
        public static void addRangeDictionary<K, V>(Dictionary<K, V> dictionary, List<KeyValuePair<K, V>> elements)
        {
            foreach (var keyValue in elements)
            {
                dictionary.Add(keyValue.Key, keyValue.Value);
            }
        }
		public static void addRange<K, V>(this Dictionary<K, V> dictionary,List<KeyValuePair<K,V>> elements)
		{
			foreach (var keyValue in elements)
			{
				dictionary.Add(keyValue.Key, keyValue.Value);
			}
		}
	}
}
