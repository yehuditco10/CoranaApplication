using CoronaApp.Entities;
using System;
using System.Collections.Generic;

namespace CoronaApp.Services.Models
{
    public class LocationSearchModel
    {

        public string city { get; set; }
        public int age { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public LocationSearchModel(string city, int age, DateTime startDate, DateTime endDate)
        {
            this.endDate = endDate;
            this.startDate = startDate;
            this.city = city;
            this.age = age;
        }
        public LocationSearchModel()
        {

        }
        public LocationSearch ToLocationSearch(LocationSearchModel locationSearchModel)
        {
            return new LocationSearch()
            {
                city = locationSearchModel.city,
                age = locationSearchModel.age,
                startDate = locationSearchModel.startDate,
                endDate = locationSearchModel.endDate
            };
        }
        public LocationSearchModel ToLocationSearchModel(LocationSearch locationSearch)
        {
            return new LocationSearchModel()
            {
                city = locationSearch.city,
                age = locationSearch.age,
                endDate = locationSearch.endDate,
                startDate = locationSearch.startDate
            };
        }
        public List<LocationSearch> ToLocationSearch(List<LocationSearchModel> locationSearchModel)
        {
            List<LocationSearch> returnObj = new List<LocationSearch>();
            LocationSearchModel searchModel = new LocationSearchModel();
            locationSearchModel.ForEach(l => returnObj.Add(searchModel.ToLocationSearch(l)));
            return returnObj;
        }
        public List<LocationSearchModel> ToLocationSearchModel(List<LocationSearch> locationSearch)
        {
            List<LocationSearchModel> returnObj = new List<LocationSearchModel>();
            LocationSearchModel  location = new LocationSearchModel();
            locationSearch.ForEach(l => returnObj.Add(location.ToLocationSearchModel(l)));
            return returnObj;
        }
    }
}