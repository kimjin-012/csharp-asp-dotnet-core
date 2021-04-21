using System;

namespace hungry_ninja
{
    interface IConsumable
    {
        string Name {get; set;}
        int Calories {get; set;}
        bool IsSpicy {get; set;}
        bool IsSweet {get; set;}
        string GetInfo();
    }
}