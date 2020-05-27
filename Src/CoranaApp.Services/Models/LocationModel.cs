using CoronaApp.Entities;
using System;

namespace CoronaApp.Services.Models
{
    public class LocationModel
    {
     
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string patientId { get; set; }

        public LocationModel(string city, DateTime startDate, DateTime endDate, string location, string patientId)
        {
            this.city = city;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.patientId = patientId;
        }
        public LocationModel()
        {

        }
        public Location ToLocation(LocationModel locationModel)
        {
            return new Location()
            {
                startDate = locationModel.startDate,
                endDate = locationModel.endDate,
                city = locationModel.city,
                location = locationModel.city,
                patientId = locationModel.patientId
            };
        }
        public LocationModel ToLocationModel(Location location)
        {
            return new LocationModel()
            {
                startDate = location.startDate,
                endDate = location.endDate,
                city = location.city,
                location = location.city,
                patientId = location.patientId
            };
        }
    }
}