using CoronaApp.Entities;

namespace CoronaApp.Services.Models
{
    public class LocationSearchModel
    {
      
        public string city { get; set; }
        public int age { get; set; }
        public LocationSearchModel(string city,int age)
        {
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
                city=locationSearchModel.city,
                age=locationSearchModel.age

             
            };
        }
        public LocationSearchModel ToLocationSearchModel(LocationSearch locationSearch)
        {
            return new LocationSearchModel()
            {
                city = locationSearch.city,
                age=locationSearch.age
               
            };
        }
    }
}