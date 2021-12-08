using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace BitcoinCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BitcoinRate currentBitcoin = GetRates();
            Console.WriteLine($"current rate: {currentBitcoin.bpi.USD.code} {currentBitcoin.bpi.USD.rate_float}");
            Console.WriteLine($"{currentBitcoin.disclaimer}");


        }

        public static BitcoinRate GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitcoinRate bitcoinData;
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoinData = JsonConvert.DeserializeObject<BitcoinRate>(response);
            }

            return bitcoinData;

        }
    } 
}
