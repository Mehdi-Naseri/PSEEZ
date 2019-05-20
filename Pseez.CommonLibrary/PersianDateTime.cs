using System;
using System.Globalization;

namespace Pseez.CommonLibrary
{
    public class PersianDateTime
    {
        public DateTime GregorianToShamsi(DateTime DateTimeGregorian)
        {
            var PersianCalendar1 = new PersianCalendar();
            var DateTimeShamsi = new DateTime(PersianCalendar1.GetYear(DateTimeGregorian),
                PersianCalendar1.GetMonth(DateTimeGregorian),
                PersianCalendar1.GetDayOfMonth(DateTimeGregorian),
                PersianCalendar1.GetHour(DateTimeGregorian),
                PersianCalendar1.GetMinute(DateTimeGregorian),
                PersianCalendar1.GetSecond(DateTimeGregorian));
            return DateTimeShamsi;
        }
    }
}