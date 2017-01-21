using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UWPWeatherLite {
    public class OpenWeatherMapAPI {

        private static string ApiKey = "";

        // when using async, return Task<object>, this tells the object will be returned when available
        public async static Task<Rootobject> GetWeatherForLatitudeAsync(double latitude, double longitude) {
            if (string.IsNullOrEmpty(ApiKey)) {
                ApiKey = File.ReadAllText("Secret/openweathermap.txt");
                System.Diagnostics.Debug.WriteLine(ApiKey);
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(string.Format(
                    "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}&units=metric",
                    latitude, longitude, ApiKey));
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Rootobject));

            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = serializer.ReadObject(memoryStream) as Rootobject;

            return data;
        }

        
    }

    [DataContract]
    public class Rootobject {

        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public Weather[] weather { get; set; }
        [DataMember]
        public string _base { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public int visibility { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
    }

    [DataContract]
    public class Coord {

        [DataMember]
        public float lon { get; set; }
        [DataMember]
        public float lat { get; set; }
    }

    [DataContract]
    public class Main {

        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float temp_min { get; set; }
        [DataMember]
        public float temp_max { get; set; }
    }

    [DataContract]
    public class Wind {

        [DataMember]
        public float speed { get; set; }
        [DataMember]
        public float deg { get; set; }
    }

    [DataContract]
    public class Clouds {

        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Sys {

        [DataMember]
        public int type { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public float message { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public long sunrise { get; set; }
        [DataMember]
        public long sunset { get; set; }
    }

    [DataContract]
    public class Weather {

        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

}
