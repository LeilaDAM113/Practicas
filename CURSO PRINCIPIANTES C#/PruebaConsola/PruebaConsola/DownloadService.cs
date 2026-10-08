using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaConsola
{
    public class DownloadService
    {
        public byte[] download(string songName)
        {
            Thread.Sleep(1000);
            return new byte[] { };
        }
        //task es una promesa, te da la promesa en este caso de que en algun momento tendremos un array de bytes
		public Task<byte[]> downloadAsync(string songName)
		{
			Thread.Sleep(1000);
			return Task.FromResult(new byte[] { });
		}

	}
}
