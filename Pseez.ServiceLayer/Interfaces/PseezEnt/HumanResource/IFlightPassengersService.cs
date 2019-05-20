using System;
using System.Collections.Generic;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource
{
    public interface IFlightPassengersService : IDisposable
    {
        IList<FlightPassengerViewModel> GetAll();
        IList<FlightPassengerViewModel> GetAllPassengersinFlight(int TimeTableId);
        IList<FlightPassengerViewModel> GetAllPassengersinFlightByFlightNumber(int FlightNumber);
    }
}