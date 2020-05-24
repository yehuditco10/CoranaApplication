namespace CoronaApp.Services.Models
{
    public class LocationSearch
    {
        public string city { get; set; }
        public LocationSearch(string city)
        {
            this.city = city;
        }
        public LocationSearch()
        {

        }
    }
}