using System;

namespace VariantB
{
    class Testing
    {
        static void Main(string[] args)
        {
            ElectricalAppliances heater = new Heater("Saturn", 220, 1.0f, 25, true);
            ElectricalAppliances musicPlayer = new MusicPlayer("Sony", 100, 0.2f);
            ElectricalAppliances wirelessMouse = new WirelessMouse("Samsung", 50, 0.1f, 125.65f);

            // включаем в розетку
            heater.ConnectToSource();
            // включаем обогреватель
            heater.StartWorking();

            // добавим приборы в массив
            ElectricalAppliances[] appliances = { heater, musicPlayer, wirelessMouse };

            Console.WriteLine();
            // Подсчет потребляемой мощности каждого прибора
            foreach (var appliance in appliances)
            {
                Console.WriteLine(appliance.PowerConsumption);
            }

            // сортируем массив приборов на основе мощности
            ElectricalAppliances.Sort(appliances);

            Console.WriteLine();
            // убеждаемся в том, что сортировка прошла успешно
            foreach (var appliance in appliances)
            {
                Console.WriteLine(appliance.Name + " " + appliance.PowerConsumption);
            }

            // получаем список приборов, чьи потребляемые мощности удовлетворяют заданному диапазону
            var list = ElectricalAppliances.FindAppliancesWithSuchRange(appliances, 3, 25);

            Console.WriteLine();
            // убеждаемся в том, что список корректен
            foreach (var appliance in list)
            {
                Console.WriteLine(appliance.Name + " " + appliance.PowerConsumption);
            }
        }
    }
}
