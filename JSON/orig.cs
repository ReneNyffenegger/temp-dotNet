//
//    https://gist.github.com/acamino/51ae7fa45708bc1e8bcda5657374aa48
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WebClientApproach
{
    [DataContract]
    internal class Contributor
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }
        [DataMember(Name = "contributions")]
        public short Contributions { get; set; }

        public override string ToString()
        {
            return $"{Login, 20}: {Contributions} contributions";
        }
    }

    internal class Program
    {
        private const string Url = "https://api.github.com/repos/twilio/twilio-csharp/contributors";

        private static void Main()
        {

//
// Prevent »Undled Exception: System.Net.WebException: The request was aborted: Could not create SSL/TLS secure channel.«
//
// ServicePointManager.Expect100Continue = true;
   ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            GetContributors();
            GetContributorsAsync();

            Console.ReadLine();
        }

        public static void GetContributors()
        {

            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nothing");

            var content = client.DownloadString(Url);

            var serializer = new DataContractJsonSerializer(typeof(List<Contributor>));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                var contributors = (List<Contributor>)serializer.ReadObject(ms);
                contributors.ForEach(Console.WriteLine);
            }
        }

        public static void GetContributorsAsync()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nothing");

            client.DownloadStringCompleted += (sender, e) =>
            {
                var serializer = new DataContractJsonSerializer(typeof(List<Contributor>));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result)))
                {
                    var contributors = (List<Contributor>)serializer.ReadObject(ms);
                    contributors.ForEach(Console.WriteLine);
                }
            };

            client.DownloadStringAsync(new Uri(Url));
        }
    }
}
