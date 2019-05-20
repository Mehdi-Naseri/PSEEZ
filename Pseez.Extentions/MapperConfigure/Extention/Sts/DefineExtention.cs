using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.ViewModels.ViewModels.Sts.Basic;
using Pseez.ViewModels.ViewModels.Sts.Journey;
using Pseez.ViewModels.ViewModels.Sts.Staff;

namespace Pseez.Extentions.MapperConfigure.Extention.Sts
{
    public static class DefineExtention
    {
        #region Sts (Context)

        #region Basic (Schema)

        #region City

        public static CityViewModel MapModelToViewModel(this City entity)
        {
            return Mapper.Map<City, CityViewModel>(entity);
        }

        public static City MapViewModelToModel(this CityViewModel entity)
        {
            return Mapper.Map<CityViewModel, City>(entity);
        }

        public static IEnumerable<CityViewModel> MapModelToViewModel(this IEnumerable<City> entity)
        {
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(entity);
        }

        public static IEnumerable<City> MapViewModelToModel(this IEnumerable<CityViewModel> entity)
        {
            return Mapper.Map<IEnumerable<CityViewModel>, IEnumerable<City>>(entity);
        }

        #endregion

        #region Gender

        public static GenderViewModel MapModelToViewModel(this Gender entity)
        {
            return Mapper.Map<Gender, GenderViewModel>(entity);
        }

        public static Gender MapViewModelToModel(this GenderViewModel entity)
        {
            return Mapper.Map<GenderViewModel, Gender>(entity);
        }

        public static IEnumerable<GenderViewModel> MapModelToViewModel(this IEnumerable<Gender> entity)
        {
            return Mapper.Map<IEnumerable<Gender>, IEnumerable<GenderViewModel>>(entity);
        }

        public static IEnumerable<Gender> MapViewModelToModel(this IEnumerable<GenderViewModel> entity)
        {
            return Mapper.Map<IEnumerable<GenderViewModel>, IEnumerable<Gender>>(entity);
        }

        #endregion

        #region Person

        public static PersonViewModel MapModelToViewModel(this Person entity)
        {
            return Mapper.Map<Person, PersonViewModel>(entity);
        }

        public static Person MapViewModelToModel(this PersonViewModel entity)
        {
            return Mapper.Map<PersonViewModel, Person>(entity);
        }

        public static IEnumerable<PersonViewModel> MapModelToViewModel(this IEnumerable<Person> entity)
        {
            return Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(entity);
        }

        public static IEnumerable<Person> MapViewModelToModel(this IEnumerable<PersonViewModel> entity)
        {
            return Mapper.Map<IEnumerable<PersonViewModel>, IEnumerable<Person>>(entity);
        }

        #endregion

        #region Province

        public static ProvinceViewModel MapModelToViewModel(this Province entity)
        {
            return Mapper.Map<Province, ProvinceViewModel>(entity);
        }

        public static Province MapViewModelToModel(this ProvinceViewModel entity)
        {
            return Mapper.Map<ProvinceViewModel, Province>(entity);
        }

        public static IEnumerable<ProvinceViewModel> MapModelToViewModel(this IEnumerable<Province> entity)
        {
            return Mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceViewModel>>(entity);
        }

        public static IEnumerable<Province> MapViewModelToModel(this IEnumerable<ProvinceViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProvinceViewModel>, IEnumerable<Province>>(entity);
        }

        #endregion

        #endregion Basic (Schema)

        #region Journey (Schema)

        #region Provider

        public static ProviderViewModel MapModelToViewModel(this Provider entity)
        {
            return Mapper.Map<Provider, ProviderViewModel>(entity);
        }

        public static Provider MapViewModelToModel(this ProviderViewModel entity)
        {
            return Mapper.Map<ProviderViewModel, Provider>(entity);
        }

        public static IEnumerable<ProviderViewModel> MapModelToViewModel(this IEnumerable<Provider> entity)
        {
            return Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderViewModel>>(entity);
        }

        public static IEnumerable<Provider> MapViewModelToModel(this IEnumerable<ProviderViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ProviderViewModel>, IEnumerable<Provider>>(entity);
        }

        #endregion

        #region ReservationPersonList

        public static ReservationPersonListViewModel MapModelToViewModel(this ReservationPersonList entity)
        {
            return Mapper.Map<ReservationPersonList, ReservationPersonListViewModel>(entity);
        }

        public static ReservationPersonList MapViewModelToModel(this ReservationPersonListViewModel entity)
        {
            return Mapper.Map<ReservationPersonListViewModel, ReservationPersonList>(entity);
        }

        public static IEnumerable<ReservationPersonListViewModel> MapModelToViewModel(
            this IEnumerable<ReservationPersonList> entity)
        {
            return Mapper.Map<IEnumerable<ReservationPersonList>, IEnumerable<ReservationPersonListViewModel>>(entity);
        }

        public static IEnumerable<ReservationPersonList> MapViewModelToModel(
            this IEnumerable<ReservationPersonListViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ReservationPersonListViewModel>, IEnumerable<ReservationPersonList>>(entity);
        }

        #endregion

        #region TimeTable

        public static TimeTableViewModel MapModelToViewModel(this TimeTable entity)
        {
            return Mapper.Map<TimeTable, TimeTableViewModel>(entity);
        }

        public static TimeTable MapViewModelToModel(this TimeTableViewModel entity)
        {
            return Mapper.Map<TimeTableViewModel, TimeTable>(entity);
        }

        public static IEnumerable<TimeTableViewModel> MapModelToViewModel(this IEnumerable<TimeTable> entity)
        {
            return Mapper.Map<IEnumerable<TimeTable>, IEnumerable<TimeTableViewModel>>(entity);
        }

        public static IEnumerable<TimeTable> MapViewModelToModel(this IEnumerable<TimeTableViewModel> entity)
        {
            return Mapper.Map<IEnumerable<TimeTableViewModel>, IEnumerable<TimeTable>>(entity);
        }

        #endregion

        #endregion Journey (Schema)

        #region Staff (Schema)

        #region BloodType

        public static BloodTypeViewModel MapModelToViewModel(this BloodType entity)
        {
            return Mapper.Map<BloodType, BloodTypeViewModel>(entity);
        }

        public static BloodType MapViewModelToModel(this BloodTypeViewModel entity)
        {
            return Mapper.Map<BloodTypeViewModel, BloodType>(entity);
        }

        public static IEnumerable<BloodTypeViewModel> MapModelToViewModel(this IEnumerable<BloodType> entity)
        {
            return Mapper.Map<IEnumerable<BloodType>, IEnumerable<BloodTypeViewModel>>(entity);
        }

        public static IEnumerable<BloodType> MapViewModelToModel(this IEnumerable<BloodTypeViewModel> entity)
        {
            return Mapper.Map<IEnumerable<BloodTypeViewModel>, IEnumerable<BloodType>>(entity);
        }

        #endregion

        #region DegreeState

        public static DegreeStateViewModel MapModelToViewModel(this DegreeState entity)
        {
            return Mapper.Map<DegreeState, DegreeStateViewModel>(entity);
        }

        public static DegreeState MapViewModelToModel(this DegreeStateViewModel entity)
        {
            return Mapper.Map<DegreeStateViewModel, DegreeState>(entity);
        }

        public static IEnumerable<DegreeStateViewModel> MapModelToViewModel(this IEnumerable<DegreeState> entity)
        {
            return Mapper.Map<IEnumerable<DegreeState>, IEnumerable<DegreeStateViewModel>>(entity);
        }

        public static IEnumerable<DegreeState> MapViewModelToModel(this IEnumerable<DegreeStateViewModel> entity)
        {
            return Mapper.Map<IEnumerable<DegreeStateViewModel>, IEnumerable<DegreeState>>(entity);
        }

        #endregion

        #region Employee

        public static EmployeeViewModel MapModelToViewModel(this Employee entity)
        {
            return Mapper.Map<Employee, EmployeeViewModel>(entity);
        }

        public static Employee MapViewModelToModel(this EmployeeViewModel entity)
        {
            return Mapper.Map<EmployeeViewModel, Employee>(entity);
        }

        public static IEnumerable<EmployeeViewModel> MapModelToViewModel(this IEnumerable<Employee> entity)
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(entity);
        }

        public static IEnumerable<Employee> MapViewModelToModel(this IEnumerable<EmployeeViewModel> entity)
        {
            return Mapper.Map<IEnumerable<EmployeeViewModel>, IEnumerable<Employee>>(entity);
        }

        #endregion

        #region EmployeeAcademicalResume

        public static EmployeeAcademicalResumeViewModel MapModelToViewModel(this EmployeeAcademicalResume entity)
        {
            return Mapper.Map<EmployeeAcademicalResume, EmployeeAcademicalResumeViewModel>(entity);
        }

        public static EmployeeAcademicalResume MapViewModelToModel(this EmployeeAcademicalResumeViewModel entity)
        {
            return Mapper.Map<EmployeeAcademicalResumeViewModel, EmployeeAcademicalResume>(entity);
        }

        public static IEnumerable<EmployeeAcademicalResumeViewModel> MapModelToViewModel(
            this IEnumerable<EmployeeAcademicalResume> entity)
        {
            return
                Mapper.Map<IEnumerable<EmployeeAcademicalResume>, IEnumerable<EmployeeAcademicalResumeViewModel>>(entity);
        }

        public static IEnumerable<EmployeeAcademicalResume> MapViewModelToModel(
            this IEnumerable<EmployeeAcademicalResumeViewModel> entity)
        {
            return
                Mapper.Map<IEnumerable<EmployeeAcademicalResumeViewModel>, IEnumerable<EmployeeAcademicalResume>>(entity);
        }

        #endregion

        #region EmployeeFamilialType

        public static EmployeeFamilialTypeViewModel MapModelToViewModel(this EmployeeFamilialType entity)
        {
            return Mapper.Map<EmployeeFamilialType, EmployeeFamilialTypeViewModel>(entity);
        }

        public static EmployeeFamilialType MapViewModelToModel(this EmployeeFamilialTypeViewModel entity)
        {
            return Mapper.Map<EmployeeFamilialTypeViewModel, EmployeeFamilialType>(entity);
        }

        public static IEnumerable<EmployeeFamilialTypeViewModel> MapModelToViewModel(
            this IEnumerable<EmployeeFamilialType> entity)
        {
            return Mapper.Map<IEnumerable<EmployeeFamilialType>, IEnumerable<EmployeeFamilialTypeViewModel>>(entity);
        }

        public static IEnumerable<EmployeeFamilialType> MapViewModelToModel(
            this IEnumerable<EmployeeFamilialTypeViewModel> entity)
        {
            return Mapper.Map<IEnumerable<EmployeeFamilialTypeViewModel>, IEnumerable<EmployeeFamilialType>>(entity);
        }

        #endregion

        #region EmployeeOrganChart

        public static EmployeeOrganChartViewModel MapModelToViewModel(this EmployeeOrganChart entity)
        {
            return Mapper.Map<EmployeeOrganChart, EmployeeOrganChartViewModel>(entity);
        }

        public static EmployeeOrganChart MapViewModelToModel(this EmployeeOrganChartViewModel entity)
        {
            return Mapper.Map<EmployeeOrganChartViewModel, EmployeeOrganChart>(entity);
        }

        public static IEnumerable<EmployeeOrganChartViewModel> MapModelToViewModel(
            this IEnumerable<EmployeeOrganChart> entity)
        {
            return Mapper.Map<IEnumerable<EmployeeOrganChart>, IEnumerable<EmployeeOrganChartViewModel>>(entity);
        }

        public static IEnumerable<EmployeeOrganChart> MapViewModelToModel(
            this IEnumerable<EmployeeOrganChartViewModel> entity)
        {
            return Mapper.Map<IEnumerable<EmployeeOrganChartViewModel>, IEnumerable<EmployeeOrganChart>>(entity);
        }

        #endregion

        #region FamilialType

        public static FamilialTypeViewModel MapModelToViewModel(this FamilialType entity)
        {
            return Mapper.Map<FamilialType, FamilialTypeViewModel>(entity);
        }

        public static FamilialType MapViewModelToModel(this FamilialTypeViewModel entity)
        {
            return Mapper.Map<FamilialTypeViewModel, FamilialType>(entity);
        }

        public static IEnumerable<FamilialTypeViewModel> MapModelToViewModel(this IEnumerable<FamilialType> entity)
        {
            return Mapper.Map<IEnumerable<FamilialType>, IEnumerable<FamilialTypeViewModel>>(entity);
        }

        public static IEnumerable<FamilialType> MapViewModelToModel(this IEnumerable<FamilialTypeViewModel> entity)
        {
            return Mapper.Map<IEnumerable<FamilialTypeViewModel>, IEnumerable<FamilialType>>(entity);
        }

        #endregion

        #region OrganChart

        public static OrganChartViewModel MapModelToViewModel(this OrganChart entity)
        {
            return Mapper.Map<OrganChart, OrganChartViewModel>(entity);
        }

        public static OrganChart MapViewModelToModel(this OrganChartViewModel entity)
        {
            return Mapper.Map<OrganChartViewModel, OrganChart>(entity);
        }

        public static IEnumerable<OrganChartViewModel> MapModelToViewModel(this IEnumerable<OrganChart> entity)
        {
            return Mapper.Map<IEnumerable<OrganChart>, IEnumerable<OrganChartViewModel>>(entity);
        }

        public static IEnumerable<OrganChart> MapViewModelToModel(this IEnumerable<OrganChartViewModel> entity)
        {
            return Mapper.Map<IEnumerable<OrganChartViewModel>, IEnumerable<OrganChart>>(entity);
        }

        #endregion

        #region Religion

        public static ReligionViewModel MapModelToViewModel(this Religion entity)
        {
            return Mapper.Map<Religion, ReligionViewModel>(entity);
        }

        public static Religion MapViewModelToModel(this ReligionViewModel entity)
        {
            return Mapper.Map<ReligionViewModel, Religion>(entity);
        }

        public static IEnumerable<ReligionViewModel> MapModelToViewModel(this IEnumerable<Religion> entity)
        {
            return Mapper.Map<IEnumerable<Religion>, IEnumerable<ReligionViewModel>>(entity);
        }

        public static IEnumerable<Religion> MapViewModelToModel(this IEnumerable<ReligionViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ReligionViewModel>, IEnumerable<Religion>>(entity);
        }

        #endregion

        #region Unit

        public static UnitViewModel MapModelToViewModel(this Unit entity)
        {
            return Mapper.Map<Unit, UnitViewModel>(entity);
        }

        public static Unit MapViewModelToModel(this UnitViewModel entity)
        {
            return Mapper.Map<UnitViewModel, Unit>(entity);
        }

        public static IEnumerable<UnitViewModel> MapModelToViewModel(this IEnumerable<Unit> entity)
        {
            return Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(entity);
        }

        public static IEnumerable<Unit> MapViewModelToModel(this IEnumerable<UnitViewModel> entity)
        {
            return Mapper.Map<IEnumerable<UnitViewModel>, IEnumerable<Unit>>(entity);
        }

        #endregion

        #endregion Staff (Schema)

        #endregion Sts (Context)
    }
}