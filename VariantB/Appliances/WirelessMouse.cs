using System;

namespace VariantB
{
    class WirelessMouse : ElectricalAppliances
    {
        public float Sensitivity { get; private set; }
        public override EnergySource EnergySource { get => EnergySource.Batteries; }

        public WirelessMouse(string name, int voltage, float amperage, float sensitivity)
            : base(name, voltage, amperage)
        {
            Sensitivity = sensitivity;
        }

        public override void ConnectToSource()
        {
            Console.WriteLine("Wireless mouse was connected to " + EnergySource);
            IsConnected = true;
        }
    }
}
