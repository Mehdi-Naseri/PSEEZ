using System;
using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Journey
{
    public class TimeTableViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Date { get; set; }
        public long? DailyServiceTime_Id { get; set; }
        public long ServiceType_Id { get; set; }
        public long? ContractDevice_Id { get; set; }
        public string Time { get; set; }
        public string FlightNumber { get; set; }
        public string Description { get; set; }
        public string FinalDate { get; set; }
        public string FinalTime { get; set; }
        public long? City_Id { get; set; }
        public long? City_To_Id { get; set; }
        public long? Provider_Id { get; set; }
        public long? Contract_Id { get; set; }
        public bool GetFromWebService { get; set; }
        public bool PresentForSubCompany { get; set; }
        public Guid? UniqueId { get; set; }
    }
}