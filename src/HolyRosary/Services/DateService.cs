using System;

namespace HolyRosary.Services
{
    public class DateService 
    {
        public DateTime GetToday()
        {
            return DateTime.Today;
        }

        public string GetDayOfWeek(DateTime? date) 
        {
            return date?.ToString("dddd");
        }
    }
}
