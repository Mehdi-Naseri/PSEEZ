using System.Collections.Generic;
using AutoMapper;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.IT;

namespace Pseez.Extentions.MapperConfigure.Extention.PseezEnt
{
    public static partial class DefineExtention
    {
       

        #region Contact

        #region ContactGroup

        public static ContactGroupViewModel MapModelToViewModel(this ContactGroup entity)
        {
            return Mapper.Map<ContactGroup, ContactGroupViewModel>(entity);
        }

        public static ContactGroup MapViewModelToModel(this ContactGroupViewModel entity)
        {
            return Mapper.Map<ContactGroupViewModel, ContactGroup>(entity);
        }

        public static IEnumerable<ContactGroupViewModel> MapModelToViewModel(this IEnumerable<ContactGroup> entity)
        {
            return Mapper.Map<IEnumerable<ContactGroup>, IEnumerable<ContactGroupViewModel>>(entity);
        }

        public static IEnumerable<ContactGroup> MapViewModelToModel(this IEnumerable<ContactGroupViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ContactGroupViewModel>, IEnumerable<ContactGroup>>(entity);
        }

        #endregion

        #region ContactList

        public static ContactListViewModel MapModelToViewModel(this ContactList entity)
        {
            return Mapper.Map<ContactList, ContactListViewModel>(entity);
        }

        public static ContactList MapViewModelToModel(this ContactListViewModel entity)
        {
            return Mapper.Map<ContactListViewModel, ContactList>(entity);
        }

        public static IEnumerable<ContactListViewModel> MapModelToViewModel(this IEnumerable<ContactList> entity)
        {
            return Mapper.Map<IEnumerable<ContactList>, IEnumerable<ContactListViewModel>>(entity);
        }

        public static IEnumerable<ContactList> MapViewModelToModel(this IEnumerable<ContactListViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ContactListViewModel>, IEnumerable<ContactList>>(entity);
        }

        #endregion

        #region Contact

        public static ContactViewModel MapModelToViewModel(this Contact entity)
        {
            return Mapper.Map<Contact, ContactViewModel>(entity);
        }

        public static Contact MapViewModelToModel(this ContactViewModel entity)
        {
            return Mapper.Map<ContactViewModel, Contact>(entity);
        }

        public static IEnumerable<ContactViewModel> MapModelToViewModel(this IEnumerable<Contact> entity)
        {
            return Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(entity);
        }

        public static IEnumerable<Contact> MapViewModelToModel(this IEnumerable<ContactViewModel> entity)
        {
            return Mapper.Map<IEnumerable<ContactViewModel>, IEnumerable<Contact>>(entity);
        }

        #endregion

        #region UserContactList

        public static UserContactListViewModel MapModelToViewModel(this UserContactList entity)
        {
            return Mapper.Map<UserContactList, UserContactListViewModel>(entity);
        }

        public static UserContactList MapViewModelToModel(this UserContactListViewModel entity)
        {
            return Mapper.Map<UserContactListViewModel, UserContactList>(entity);
        }

        public static IEnumerable<UserContactListViewModel> MapModelToViewModel(this IEnumerable<UserContactList> entity)
        {
            return Mapper.Map<IEnumerable<UserContactList>, IEnumerable<UserContactListViewModel>>(entity);
        }

        public static IEnumerable<UserContactList> MapViewModelToModel(this IEnumerable<UserContactListViewModel> entity)
        {
            return Mapper.Map<IEnumerable<UserContactListViewModel>, IEnumerable<UserContactList>>(entity);
        }

        #endregion

        #region UserDefaultContactList

        public static UserDefaultContactListViewModel MapModelToViewModel(this UserDefaultContactList entity)
        {
            return Mapper.Map<UserDefaultContactList, UserDefaultContactListViewModel>(entity);
        }

        public static UserDefaultContactList MapViewModelToModel(this UserDefaultContactListViewModel entity)
        {
            return Mapper.Map<UserDefaultContactListViewModel, UserDefaultContactList>(entity);
        }

        public static IEnumerable<UserDefaultContactListViewModel> MapModelToViewModel(
            this IEnumerable<UserDefaultContactList> entity)
        {
            return Mapper.Map<IEnumerable<UserDefaultContactList>, IEnumerable<UserDefaultContactListViewModel>>(entity);
        }

        public static IEnumerable<UserDefaultContactList> MapViewModelToModel(
            this IEnumerable<UserDefaultContactListViewModel> entity)
        {
            return Mapper.Map<IEnumerable<UserDefaultContactListViewModel>, IEnumerable<UserDefaultContactList>>(entity);
        }

        #endregion

        #endregion

        //#region Server
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public static ContactUsModel ToContactUsModel(this ContactU entity)
        //{
        //    return Mapper.Map<ContactU, ContactUsModel>(entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public static AddContactUsModel ToAddContactUsModel(this ContactU entity)
        //{
        //    return Mapper.Map<ContactU, AddContactUsModel>(entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public static ContactU ToEntity(this AddContactUsModel model)
        //{
        //    return Mapper.Map<AddContactUsModel, ContactU>(model);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <param name="entity"></param>
        //public static void ToEntity(this AddContactUsModel model, ContactU entity)
        //{
        //    Mapper.Map(model, entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public static ContactU ToEntity(this ContactUsModel model)
        //{
        //    return Mapper.Map<ContactUsModel, ContactU>(model);
        //}

        //#endregion
    }
}