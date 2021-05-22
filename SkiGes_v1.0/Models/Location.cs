using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiGes_v1._0.Models
{
    public class Location
    {
        private float latitude;
        private float longitude;

        public Location(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public float distance(Location loc)
        {
            float lat1 = this.latitude;
            float lat2 = loc.latitude;
            lat1 = lat1 * 0.017453292500000002F;
            lat2 = (lat2 * 0.017453292500000002F);
            float delta_lat = lat2 - lat1;
            float delta_lon = (loc.longitude - this.longitude) * 0.017453292500000002F;
            float temp = (float)(Math.Pow(Math.Sin(delta_lat / 2.0F), 2.0F) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(delta_lon / 2.0F), 2.0F));
            return (float)(12756.4F * Math.Atan2(Math.Sqrt(temp), Math.Sqrt(1.0D - temp)));
        }
    }
}