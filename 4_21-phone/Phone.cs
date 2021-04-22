using System;

namespace phone
{
    abstract class Phone
    {
        private string _versionNumber;
        public string VersionNumber {
            get {return _versionNumber;}
        }
        private int _batteryPercentage;
        public int BatteryPercentage 
        {
            get {return _batteryPercentage;}
        }
        // public int BatteryPercentage 
        // {
        //     get { return _batteryPercentage;}
        //     set 
        //     {
        //         if(value < 0){
        //             _batteryPercentage = 0;
        //         } else if(value > 100) {
        //             _batteryPercentage = 100;
        //         } else {
        //             _batteryPercentage = value;
        //         }
        //     }
        // }
        private string _carrier;
        public string Carrier
        {
            get {return _carrier;}
        }
        private string _ringTone;
        public string RingTone
        {
            get {return _ringTone;}
        }
        public Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone)
            {
                _versionNumber = versionNumber;
                _batteryPercentage = batteryPercentage;
                _carrier = carrier;
                _ringTone = ringTone;
            }

        // abstract method. This method will be implemented by the subclasses
        public abstract void DisplayInfo();
        // public getters and setters removed for brevity. Please implement them yourself
    }
}