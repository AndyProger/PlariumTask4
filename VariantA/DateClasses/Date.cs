using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantA
{
    class Date
    {
        public Year Year { get; }
        public Month Month { get; }
        public Day Day { get; }

        public Date(uint day, uint month, uint year)
        {
            Day = new Day(day);
            Month = new Month(month);
            Year = new Year(year);
        }

        public DayOfWeek GetDayOfWeek() => new DateTime((int)Year.Year_, (int)Month.Month_, (int)Day.Day_).DayOfWeek;

        public int GetDayOfYear()
        {
            bool isLeap = Year.IsLeap;
            var daysOfYear = 0;

            for(uint i = 1; i < Month.Month_; i++)
            {
                daysOfYear += new Month(i).GetDays(isLeap);
            }

            return daysOfYear + (int)Day.Day_;
        }

        public int DaysBetween(Date date)
        {
            DateTime endDate = 
                new DateTime(
                    (int)Year.Year_, 
                    (int)Month.Month_, 
                    (int)Day.Day_);
            DateTime startDate = 
                new DateTime(
                (int)date.Year.Year_, 
                (int)date.Month.Month_, 
                (int)date.Day.Day_);

            return (int)Math.Abs((endDate - startDate).TotalDays);
        }

        public override bool Equals(object obj)
        {
            Date otherDate = obj as Date;
            return otherDate is not null ? 
                otherDate.Year.Equals(Year) && 
                otherDate.Month.Equals(Month) && 
                otherDate.Day.Equals(Day) : false;
        }

        public override string ToString() => $"{Day}/{Month}/{Year}";
    }
}
