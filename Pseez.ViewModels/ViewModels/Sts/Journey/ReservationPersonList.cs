using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Journey
{
    public class ReservationPersonListViewModel
    {
        [Key]
        public long Id { get; set; }

        public long Reservation_Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public int Age { get; set; }
        public string Description { get; set; }
        public long EmployeeSupport_Id { get; set; }
        public long Passenger_Id { get; set; }
        public long Person_Id { get; set; }
        public long TimeTable_Id { get; set; }
        public long PassengerType_Id { get; set; }
        public bool Sent { get; set; }
        public bool ExtraRation { get; set; }
        public string PassengerID { get; set; }
        public string Result { get; set; }
        public long UniqueId { get; set; }
        public long ReservationState_PersonList_Id { get; set; }
        public byte SurplusList { get; set; }
    }
}