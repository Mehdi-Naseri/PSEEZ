using System;
using System.Collections.Generic;
using System.Linq;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ServiceLayer.Interfaces.PseezEnt.HumanResource;
using Pseez.ViewModels.ViewModels.PseezEnt.HumanResource;
//using Pseez.DomainClasses.Models.PseezEnt;
//using Pseez.ServiceLayer.Interfaces.PseezEnt;
//using Pseez.DataLayer.IUnitOfWork;

namespace Pseez.ServiceLayer.EFServices.PseezEnt.HumanResource
{
    public class EfEmployeeDetailService : IEmployeeDetailService
    {
        protected IUnitOfWorkSts _uow;
        //protected IDbSet<EmployeesDetailViewModel> _tEntities;

        public EfEmployeeDetailService(IUnitOfWorkSts uow)
        {
            _uow = uow;
            //_tEntities = _uow.Set<EmployeesDetailViewModel>)();
        }

        public IList<EmployeesDetailViewModel> GetAll()
        {
            return GenerateEmployeeList(true);
        }

        public IList<EmployeesDetailViewModel> GetFew(int numberofReturnedEmployee)
        {
            return GenerateEmployeeList(false, numberofReturnedEmployee);
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        private IList<EmployeesDetailViewModel> GenerateEmployeeList(bool boolShowAllEmployee,
            int numberofReturnedEmployee = 0)
        {
            //جهت بالا بردن سرعت تنها 10 کارمند اول نمایش داده میشوند.
            IEnumerable<Person> listPerson = boolShowAllEmployee == false
            ? _uow.Set<Person>().Take(numberofReturnedEmployee).ToList()
            : _uow.Set<Person>().ToList();

            var Result = new List<EmployeesDetailViewModel>();

            foreach (var Person1 in listPerson)
            {
                var EmplyeesDetailsViewModel1 = new EmployeesDetailViewModel();
                //From Basic.Person
                EmplyeesDetailsViewModel1.Id = Person1.Id;
                EmplyeesDetailsViewModel1.Name = Person1.Name;
                EmplyeesDetailsViewModel1.Family = Person1.Family;
                EmplyeesDetailsViewModel1.FatherName = Person1.FatherName;
                EmplyeesDetailsViewModel1.BirthDate = Person1.BirthDate;
                if (Person1.City_Id != null)
                {
                    EmplyeesDetailsViewModel1.City = Person1.City.Name;
                    EmplyeesDetailsViewModel1.Province = Person1.City.Province.Name;
                }
                EmplyeesDetailsViewModel1.Shenasnameh = Person1.IdNumber;
                EmplyeesDetailsViewModel1.NationalCode = Person1.NationalCode;
                EmplyeesDetailsViewModel1.Gender = Person1.Gender.Title;
                EmplyeesDetailsViewModel1.Mobile = Person1.Mobile;
                //From Staff.Employee
                if (Person1.Employee != null)
                {
                    EmplyeesDetailsViewModel1.PersoneliCode = Person1.Employee.Code;
                    EmplyeesDetailsViewModel1.EmploymentDate = Person1.Employee.PrimaryEmploymentDate;
                    if (Person1.Employee.Religion != null)
                    {
                        EmplyeesDetailsViewModel1.Religion = Person1.Employee.Religion.Name;
                    }
                    EmplyeesDetailsViewModel1.Email = Person1.Employee.EMail;
                    if (Person1.Employee.BloodType_Id != null)
                    {
                        EmplyeesDetailsViewModel1.BloodType = Person1.Employee.BloodType.Title;
                    }
                    EmplyeesDetailsViewModel1.Email = Person1.Employee.EMail;
                    if (Person1.Employee.EmployeeFamilialTypes.Count() > 0)
                    {
                        EmplyeesDetailsViewModel1.MartialStatus =
                            Person1.Employee.EmployeeFamilialTypes.Last().FamilialType.Title;
                        EmplyeesDetailsViewModel1.MartialDate = Person1.Employee.EmployeeFamilialTypes.Last().Date;
                    }
                    if (Person1.Employee.EmployeeAcademicalResumes.Count() > 0)
                    {
                        EmplyeesDetailsViewModel1.DegreeState =
                            Person1.Employee.EmployeeAcademicalResumes.OrderBy(r => r.GraduatedYear)
                                .Last()
                                .DegreeState.Title;
                    }

                    if (Person1.Employee.EmployeeOrganCharts.Count() > 0)
                    {
                        var longEmployeeOrganChartId =
                            Person1.Employee.EmployeeOrganCharts.OrderBy(r => r.ToDate).Last().OrganChart_Id;
                        var longUnitId =
                            _uow.Set<OrganChart>().Where(r => r.Id == longEmployeeOrganChartId).First().Unit_Id;
                        EmplyeesDetailsViewModel1.Unit = _uow.Set<Unit>().Where(r => r.Id == longUnitId).First().Name;
                    }
                }
                Result.Add(EmplyeesDetailsViewModel1);
            }
            return Result.ToList();
        }
    }
}