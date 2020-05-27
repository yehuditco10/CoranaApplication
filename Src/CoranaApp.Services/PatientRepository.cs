using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Dal;
using CoronaApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Services
{
    public class PatientRepository : IPatientRepository
    {
        public PatientModel Get(string id)
        {
            using (CoronaContext coronaContext = new CoronaContext())
            {
                Patient patient = coronaContext.Patients.Include(p => p.locations)
                    .FirstOrDefault(pa => pa.id == id);
                if (patient == null)
                {
                    throw new Exception("didn't find");
                }
                if (patient.locations.Count() > 0)
                {
                    PatientModel p = new PatientModel();
                    return p.ToPatientModel(patient);
                }
            }
            throw new Exception("no location");
        }

        public void Save(PatientModel patient)
        {
            using (CoronaContext coronaContext = new CoronaContext())
            {
                try
                {
                    List<Location> locationsToUpdate = coronaContext.Locations.Where(l => l.patientId == patient.id).ToList();
                    coronaContext.Locations.RemoveRange(locationsToUpdate);
                    coronaContext.Locations.AddRange(patient.ToPatient().locations);
                    coronaContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("adding failed");
                }
            }

        }


        //public static async Task<List<Location>> GetLocationsByPatientAsync(String id)
        //{
        //    try
        //    {
        //        if (LocationRepository.locations.FirstOrDefault(l => l.patientId == id) != null)
        //        {
        //            return LocationRepository.locations.Where(i => i.patientId == id).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("we didn't find");
        //    }

        //    return null;
        //}
        //public async Task<List<Location>> Get(string patienId)
        //{
        //    try
        //    {
        //        var results = await GetLocationsByPatientAsync(patienId);
        //        if (results == null || results.Count() <= 0)
        //        {
        //            throw new Exception("we didn't find");

        //        }
        //        return results;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.ToString());
        //        //return this.StatusCode(StatusCodes.Status500InternalServerError, "data failed");
        //    }
        //}
    }
}
