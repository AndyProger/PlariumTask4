using System;
using System.Globalization;

namespace VariantA
{
    class Month
    {
        public uint Month_ { get; }

        public Month() => Month_ = (uint)DateTime.Now.Month;

        public Month(uint month)
        {
            if (month >= 1 && month <= 12)
                Month_ = month;
            else
                throw new ArgumentException();
        }

        public int GetDays(bool leapYear)
        {
            if (leapYear && Month_ == 2)
                return 29;

            return (int)(28.0 + (Month_ + Math.Floor(Month_ / 8.0))
                % 2 + 2 % Month_ + 2 * Math.Floor(1.0 / Month_));
        }

        public override string ToString()
        {
            return CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.GetMonthName((int)Month_);
        }

        public override bool Equals(object obj)
        {
            Month otherMonth = obj as Month;
            return otherMonth is not null ? otherMonth.Month_ == Month_ : false;
        }
    }
}
