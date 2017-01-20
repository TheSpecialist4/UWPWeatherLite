using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWPWeatherLite {
    public class CityIdManager {

        //private static CityIdManager INSTANCE = new CityIdManager();

        private List<CityRootobject> Cities;

        public CityIdManager() {
            Cities = new List<CityRootobject>();
            // load cities from json file
            ReadCityFile();
        }

        //public static CityIdManager GetInstance() {
        //    return INSTANCE;
        //}

        private void ReadCityFile() {
            //foreach (var line in File.ReadLines(@"C:\Users\kaamr\Documents\Visual Studio 2015\Projects\UWPWeatherLite\UWPWeatherLite\Data", Encoding.UTF8)) {
            //    var city = JsonConvert.DeserializeObject<CityRootobject>(line);
            //    Cities.Add(city);
            //}
            //System.Diagnostics.Debug.WriteLine("City count: " + Cities.Count);
        }

    }

    [DataContract]
    public class CityRootobject {
        [DataMember]
        public int _id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public CityCoord coord { get; set; }
    }

    [DataContract]
    public class CityCoord {
        [DataMember]
        public float lon { get; set; }
        [DataMember]
        public float lat { get; set; }
    }

}
