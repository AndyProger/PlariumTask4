using System;

namespace VariantA
{
    class Testing
    {
        static void Main(string[] args)
        {
            Date date = new Date(16,10,2021);

            // день недели по заданной дате
            Console.WriteLine(date.GetDayOfWeek());

            // день по счету в году
            Console.WriteLine(date.GetDayOfYear());

            // количество дней, в заданном временном промежутке
            Date otherDate = new Date(1, 1, 2020);
            Console.WriteLine(date.DaysBetween(otherDate));

            // проверка на високосность
            Console.WriteLine(new Year(2020).IsLeap); // true
            Console.WriteLine(new Year(2021).IsLeap); // false

            // количество дней в месяце
            Console.WriteLine(new Month(2).GetDays(false)); // 28
            Console.WriteLine(new Month(2).GetDays(true)); // 29
            Console.WriteLine(new Month(12).GetDays(false)); // 31

            // преобразования индекса дня недели в соотв. элемент перечисления
            DayOfWeek dayOfWeek = Day.ValueOf(0);
            DayOfWeek dayOfWeek1 = Day.ValueOf(6);
            Console.WriteLine(dayOfWeek); // Sunday
            Console.WriteLine(dayOfWeek1); // Saturday
        }
    }
}
