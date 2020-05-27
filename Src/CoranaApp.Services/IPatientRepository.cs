using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        PatientModel Get(string id);

        void Save(PatientModel patient);
    }
}
