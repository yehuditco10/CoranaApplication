using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services;

namespace CoronaApp.Services
{
    public class PatientRepository : IPatientRepository
    {
        public Patient Get(string id)
        {
            Patient patient = new Patient(id);
            if (patient.locations.Count() > 0)
                return patient;
            throw new Exception("didn't find");
        }

        public void Save(Patient patient)
        {
            try
            {
               LocationRepository.locations.RemoveAll(l => l.patientId == patient.id);
               LocationRepository.locations.AddRange(patient.locations);
            }
            catch (Exception)
            {
                throw new Exception("adding failed");
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
