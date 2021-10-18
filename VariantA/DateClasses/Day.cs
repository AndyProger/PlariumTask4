using System;

namespace VariantA
{
    class Day
    {
        public uint Day_ { get; }

        public Day() => Day_ = (uint)DateTime.Now.Day;

        public Day(uint day)
        {
            if (day >= 1 && day <= 31)
                Day_ = day;
            else
                throw new ArgumentException();
        }

        public static DayOfWeek ValueOf(int index)
        {
            if(index >= 0 && index <= 6)
                return (DayOfWeek)index;
            else
                throw new ArgumentException();
        }

        public override string ToString() => Day_.ToString();

        public override bool Equals(object obj)
        {
            Day otherDay = obj as Day;
            return otherDay is not null ? otherDay.Day_ == Day_ : false;
        }
    }
}
