using System;
using System.Collections.Generic;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;

namespace Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource
{
    public interface IEmployeeDetailService : IDisposable
    {
        IList<EmployeesDetailViewModel> GetAll();
        IList<EmployeesDetailViewModel> GetFew(int numberofReturnedEmployee);
    }
}