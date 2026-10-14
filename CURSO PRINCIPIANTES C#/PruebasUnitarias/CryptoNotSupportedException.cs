using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRateCalculation
{
    public class CryptoNotSupportedException : Exception
    {
        public CryptoNotSupportedException(string cryptoCode) : base($"Unsupported crypto {cryptoCode}"){
            }
    }
}
