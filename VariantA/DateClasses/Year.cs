using System;

namespace VariantA
{
    class Year
    {
        public uint Year_ { get; }
        public bool IsLeap { get => IsYearLeap(Year_); }

        public Year() => Year_ = (uint)DateTime.Now.Year;
        public Year(uint year) => Year_ = year;
        private bool IsYearLeap(uint year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        public override string ToString() => Year_.ToString();

        public override bool Equals(object obj)
        {
            Year otherYear = obj as Year;
            return otherYear is not null ? otherYear.Year_ == Year_ : false;
        }
    }
}
