using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;
//using Pseez.DomainClasses.Models.PseezEnt;
//using Pseez.ServiceLayer.Interfaces.PseezEnt;
//using Pseez.DataLayer.IUnitOfWork;


namespace Pseez.ServiceLayer.EFServices.PseezEnt.HumanResource
{
    public class EfFlightPassengersService : IFlightPassengersService
    {
        protected IDbSet<ReservationPersonList> _reservationPersonList;
        protected IDbSet<TimeTable> _timeTable;
        protected IUnitOfWorkSts _uow;

        public EfFlightPassengersService(IUnitOfWorkSts uow)
        {
            _uow = uow;
            _reservationPersonList = _uow.Set<ReservationPersonList>();
            _timeTable = _uow.Set<TimeTable>();
        }

        public IList<FlightPassengerViewModel> GetAll()
        {
            IList<FlightPassengerViewModel> passengers =
                _reservationPersonList.Select(a => new FlightPassengerViewModel {Name = a.Name, Family = a.Family})
                    .ToList();
            return passengers;
        }

        public IList<FlightPassengerViewModel> GetAllPassengersinFlight(int TimeTableId)
        {
            IList<FlightPassengerViewModel> passengers = _reservationPersonList
                .Where(a => a.TimeTable_Id == TimeTableId)
                .Select(a => new FlightPassengerViewModel {Name = a.Name, Family = a.Family})
                .ToList();
            return passengers;
        }

        public IList<FlightPassengerViewModel> GetAllPassengersinFlightByFlightNumber(int FlightNumber)
        {
            var TimeTableId = (int) _timeTable.Where(a => int.Parse(a.FlightNumber) == FlightNumber).FirstOrDefault().Id;
            IList<FlightPassengerViewModel> passengers = _reservationPersonList
                .Where(a => a.TimeTable_Id == TimeTableId)
                .Select(a => new FlightPassengerViewModel {Name = a.Name, Family = a.Family})
                .ToList();
            return passengers;
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}