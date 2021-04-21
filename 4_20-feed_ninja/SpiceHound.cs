using System;

namespace hungry_ninja
{
    class SpiceHound : Ninja
    {
        public override bool IsFull 
        {
            get {
                return calorieIntake > 1200;
            }
        }
        public override void Consume(IConsumable item)
        {
            if(IsFull){
                Console.WriteLine("This guy can't eat more bro...");
            } else {
                calorieIntake += item.Calories;
                if(item.IsSpicy){
                    calorieIntake -= 5;
                }
                ConsumeFoodHistory.Add(item);
                Console.WriteLine($"Spice Hound comsumed: {item.Name}");
                Console.WriteLine(item.GetInfo());
                Console.WriteLine("*************NEXT*************");
            }
        }
    }
}