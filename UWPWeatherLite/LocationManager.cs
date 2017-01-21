using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace UWPWeatherLite {
    public class LocationManager {

        public async static Task<Geoposition> GetPositionAsync() {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed) {
                return null;
            }

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var location = await geolocator.GetGeopositionAsync();

            return location;
        }
    }
}
