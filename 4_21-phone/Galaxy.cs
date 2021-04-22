using System;

namespace phone
{
    class Galaxy : Phone, IRingable
    {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) : base(versionNumber, batteryPercentage, carrier, ringTone)
        {
            // None here
        }

        public string Ring()
        {
            return $"(Ringing): ~ ~ ~ {this.RingTone} ~ ~ ~";
        }
        public string Unlock()
        {
            return $"Galaxy {this.VersionNumber} unlocked with a Face Scan";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("##############################");
            Console.WriteLine($"Galaxy: {this.VersionNumber}");
            Console.WriteLine($"Battery Percentage: {this.BatteryPercentage}");
            Console.WriteLine($"Carrier: {this.Carrier}");
            Console.WriteLine($"Ring Tone: {this.RingTone}");
            Console.WriteLine("##############################");
        }
    }
}