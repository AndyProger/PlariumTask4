using System;

namespace VariantB
{
    class Heater : ElectricalAppliances, ICool
    {
        public int HeatingArea { get; private set; }
        public bool OverheatProtection { get; private set; }
        public override EnergySource EnergySource { get => EnergySource.Rosette; }

        public Heater(string name, int voltage, float amperage, int hArea, bool protection) 
            : base(name, voltage, amperage)
        {
            HeatingArea = hArea;
            OverheatProtection = protection;
        }

        public override void ConnectToSource()
        {
            Console.WriteLine("Heater was connected to " + EnergySource);
            IsConnected = true;
        }

        public override void StartWorking()
        {
            base.StartWorking();

            Console.WriteLine("Warming up!");
        }

        public void Cooling()
        {
            if (!OverheatProtection)
                Console.WriteLine("Cooling");
        }
    }
}
