using System;
using System.Collections.Generic;
using System.Linq;

namespace VariantB
{
    class MusicPlayer : ElectricalAppliances
    {
        public override EnergySource EnergySource { get => EnergySource.Accumulator; }
        private List<string> _listOfSongs;
        public List<string> ListOfSongs { get => new List<string>(_listOfSongs); }

        public MusicPlayer(string name, int voltage, float amperage) 
            : base(name, voltage, amperage)
        {
            _listOfSongs = new List<string>();
        }

        public override void ConnectToSource()
        {
            Console.WriteLine("MusicPlayer was connected to " + EnergySource);
            IsConnected = true;
        }

        public void AddSong(string song) => _listOfSongs.Add(song);

        public void RemoveSong(string song)
        {
            if (_listOfSongs.Contains(song))
            {
                _listOfSongs.Remove(song);
            }
            else
            {
                throw new ArgumentException("This song cannot be found!");
            }
        }

        public override void StartWorking()
        {
            base.StartWorking();

            if (_listOfSongs.Any())
            {
                Console.WriteLine("Playing songs!");
            }
            else
            {
                Console.WriteLine("List of songs is empty!");
            }
        }
    }
}
