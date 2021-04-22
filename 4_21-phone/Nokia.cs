using System;

namespace phone
{
    class Nokia : Phone, IRingable
    {
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) : base(versionNumber, batteryPercentage, carrier, ringTone)
        {
            // None here
        }

        public string Ring()
        {
            return $"(Ringing): . . . {this.RingTone} . . .";
        }
        public string Unlock()
        {
            return $"Nokia {this.VersionNumber} unlocked with a Hammer";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine($"Nokia: {this.VersionNumber}");
            Console.WriteLine($"Battery Percentage: {this.BatteryPercentage}");
            Console.WriteLine($"Carrier: {this.Carrier}");
            Console.WriteLine($"Ring Tone: {this.RingTone}");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
    }
}