using System.Collections.Generic;
using System.Linq;
using CoronaApp.Entities;
namespace CoronaApp.Services.Models
{
    public class PatientModel
    {
        public string id { get; set; }
        public int age { get; set; }
        public List<LocationModel> locations { get; set; }
        public PatientModel()
        {

        }
        public PatientModel(string id,int age)
        {
            this.id = id;
            this.age = age;
            //locations=LocationRepository.locations.Where(i => i.patientId == id).ToList();
        }
        public Patient ToPatient()
        {
            List<Location> locations = new List<Location>();
            foreach (var item in this.locations)
            {
                locations.Add(new Location()
                {
                    startDate = item.startDate,
                    endDate = item.endDate,
                    city = item.city,
                    location = item.location,
                    patientId = item.patientId
                }
                    );
            }
            return new Patient()
            {
                id = this.id,
                age=this.age,
                locations = locations
            };
        }

        public PatientModel ToPatientModel(Patient patient)
        {
            List<LocationModel> locationsModel = new List<LocationModel>();
            foreach (var item in patient.locations)
            {
                locationsModel.Add(new LocationModel()
                {
                    startDate = item.startDate,
                    endDate = item.endDate,
                    city = item.city,
                    location = item.location,
                    patientId = item.patientId
                }
                    );
            }
            return new PatientModel()
            {
                id = patient.id,
                locations = locationsModel
            };
        }

    }
}