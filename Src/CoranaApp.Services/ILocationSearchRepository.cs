using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface ILocationSearchRepository
    {
        ICollection<LocationModel> Get(LocationSearchModel locationSearch);
    }
}
