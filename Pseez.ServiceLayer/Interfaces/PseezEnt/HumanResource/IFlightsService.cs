using System;
using System.Collections.Generic;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource
{
    public interface IFlightsService : IDisposable
    {
        IList<FlightListViewModel> GetAll();
        IList<FlightListViewModel> GetInMonth(string year, string month);
    }
}