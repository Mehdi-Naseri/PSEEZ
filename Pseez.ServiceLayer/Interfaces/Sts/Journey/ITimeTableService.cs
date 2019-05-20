using System.Collections.Generic;
using Pseez.DomainClasses.Models.Sts.Journey;

namespace Pseez.ServiceLayer.Interfaces.Sts.Journey
{
    public interface ITimeTableService : _IGenericService<TimeTable>
    {
        IList<TimeTable> GetAllinMonth(string stringDateFilter);
    }
}