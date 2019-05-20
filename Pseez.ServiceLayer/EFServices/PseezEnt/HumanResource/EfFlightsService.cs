using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;
//using Pseez.DomainClasses.Models.PseezEnt;
//using Pseez.ServiceLayer.Interfaces.PseezEnt;
//using Pseez.DataLayer.IUnitOfWork;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.HumanResource
{
    public class EfFlightsService : IFlightsService
    {
        protected IDbSet<City> _city;
        protected IDbSet<Provider> _provider;
        protected IDbSet<TimeTable> _timeTable;
        protected IUnitOfWorkSts _uow;

        public EfFlightsService(IUnitOfWorkSts uow)
        {
            _uow = uow;
            _timeTable = _uow.Set<TimeTable>();
            _city = _uow.Set<City>();
            _provider = _uow.Set<Provider>();
        }

        public IList<FlightListViewModel> GetAll()
        {
            var flightLists = GetFlightLists();
            return flightLists;
        }

        public IList<FlightListViewModel> GetInMonth(string year, string month)
        {
            var flightLists = GetFlightLists(year, month);
            return flightLists;
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        private IList<FlightListViewModel> GetFlightLists(string year = null, string month = null)
        {
            IQueryable<TimeTable> timeTables;
            if (year != null)
            {
                var stringDateFilter = year + "/" + month;
                timeTables = _timeTable.Where(r => r.Date.StartsWith(stringDateFilter));
            }
            else
            {
                timeTables = _timeTable;
            }

            IList<FlightListViewModel> FlightListsViewModel = (from timeTable in timeTables.ToList()
                select new FlightListViewModel
                {
                    Date = timeTable.Date,
                    Time = timeTable.Time,
                    CityFrom = _city.Find(timeTable.City_Id).Name,
                    CityTo = _city.Find(timeTable.City_To_Id).Name,
                    Provider = _provider.Find(timeTable.Provider_Id).Name,
                    TimeTable = (int) timeTable.Id,
                    FlightNumber = int.Parse(timeTable.FlightNumber)
                }).ToList();
            return FlightListsViewModel;
        }
    }
}