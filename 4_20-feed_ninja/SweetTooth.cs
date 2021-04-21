using System;

namespace hungry_ninja
{
    class SweetTooth : Ninja
    {
        public override bool IsFull 
        {
            get { return calorieIntake > 1500;}
        }
        public override void Consume(IConsumable item)
        {
            if(this.IsFull){
                Console.WriteLine("SweetTooth is Full bro, can not eat more...");
            } else {
                calorieIntake += item.Calories;
                if(item.IsSweet){
                    calorieIntake += 10;
                }
                ConsumeFoodHistory.Add(item);
                Console.WriteLine("Sweet Tooth ate: " + item.Name);
                Console.WriteLine(item.GetInfo());
                Console.WriteLine("*************NEXT*************");
            }
        }
    }
}