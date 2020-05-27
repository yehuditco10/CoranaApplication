using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CoronaApp.Dal;
using CoronaApp.Entities;
using System.Linq;

namespace CoronaApp.Services
{
   public class LocationSearchRepository:ILocationSearchRepository
    {
        public ICollection<LocationModel> Get(LocationSearchModel locationSearchModel)
        {
            try
            {
                using (CoronaContext coronaContext = new CoronaContext())
                {
                    if(locationSearchModel.age!=0)
                    {
                        List<Patient> patients = coronaContext.Patients.Where(p => p.age == locationSearchModel.age).ToList();
                        if (patients.Count() > 0)
                        {
                            List<LocationModel> locationsByAge = new List<LocationModel>();
                            foreach (var patient in patients)
                            {
                                List<Location> locations = coronaContext.Locations.Where(l => l.patientId == patient.id).ToList();
                                if (locations.Count() > 0)
                                {
                                    foreach (var location in locations)
                                    {
                                        locationsByAge.Add(new LocationModel()
                                        {
                                            startDate = location.startDate,
                                            endDate = location.endDate,
                                            city = location.city,
                                            location = location.location,
                                            patientId = location.patientId,

                                        });
                                    }
                                }
                            }
                            return locationsByAge;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            throw new Exception("No locations");
        }

       

    }
}
