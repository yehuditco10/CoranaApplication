using System.Collections.Generic;
using System.Linq;

namespace CoronaApp.Services.Models
{
    public class Patient
    {
        public string id { get; set; }
        public List<Location> locations { get; set; }
        public Patient()
        {

        }
        public Patient(string id)
        {
            this.id = id;
            locations=LocationRepository.locations.Where(i => i.patientId == id).ToList();
        }

    }
}