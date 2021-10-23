using System;
using System.Collections.Generic;

namespace VariantB
{
    interface ICool
    {
        // охлаждение
        public void Cooling();
    }

    enum EnergySource
    {
        Rosette,
        Batteries,
        Accumulator
    }

    abstract class ElectricalAppliances : IComparable<ElectricalAppliances>
    {
        public string Name { get; private set; }
        public int Voltage { get; private set; }
        public float Amperage { get; private set; }
        public float PowerConsumption { get => CountPowerConsumption(); }
        public bool IsConnected { get; protected set; }
        public bool IsWorking { get; protected set; }

        // источник энергии у каждого прибора может быть разным 
        public abstract EnergySource EnergySource { get; }

        protected ElectricalAppliances(string name, int voltage, float amperage)
        {
            Name = name;
            Voltage = voltage;
            Amperage = amperage;
        }

        // сортировка приборов на основе мощности
        public static void Sort(ElectricalAppliances[] appliances) => Array.Sort(appliances);

        public int CompareTo(ElectricalAppliances other)
        {
            if (other is null)
                throw new NullReferenceException();

            return PowerConsumption.CompareTo(other.PowerConsumption);
        }

        // возвращает список приборов, попадающие в заданный диапазон энергопотребления
        public static List<ElectricalAppliances> FindAppliancesWithSuchRange(
            ElectricalAppliances[] arr, float from, float to)
        {
            if (arr is null || to < from)
                throw new ArgumentException();

            var list = new List<ElectricalAppliances>();

            foreach(var appliances in arr)
            {
                if (appliances is not null && 
                    appliances.PowerConsumption >= from && 
                    appliances.PowerConsumption <= to)
                {
                    list.Add(appliances);
                }
                else
                {
                    continue;
                }   
            }

            return list;
        }

        // подсчет потребляемой мощности
        private float CountPowerConsumption() => Voltage * Amperage;

        // подключение к источнику (батарея, разетка и т. д.) каждый прибор осуществляет по-своему
        public abstract void ConnectToSource();

        // каждый прибор делает что-то, но перед этим стоит проверить подключен ли прибор
        public virtual void StartWorking()
        {
            if (!IsConnected)
            {
                Console.WriteLine("Firstly connect the device!");
                return;
            }

            if (IsWorking)
            {
                Console.WriteLine("Appliance is already working!");
                return;
            }

            IsWorking = true;
        }

        // каждый наследник, может переопределить свою логику отключения, если базовая ему не подходит
        public virtual void StopWorking()
        {
            if (IsWorking)
            {
                Console.WriteLine("Appliance stop working!");
                IsWorking = false;
            }
            else
            {
                Console.WriteLine("Appliance is already off");
            }
        }
    }
}
