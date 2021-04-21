using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    abstract class Ninja
    {
        protected int calorieIntake;
        public List<IConsumable> ConsumeFoodHistory;
        // public bool IsFull
        // {
        //     get { 
        //         if(calorieIntake > 1200){
        //             return true;
        //         } else {
        //             return false;
        //         };
        //     }
        // }
        public abstract bool IsFull {get;}
        public abstract void Consume (IConsumable item);
        public Ninja()
        {
            calorieIntake = 0;
            ConsumeFoodHistory = new List<IConsumable>();
        }
        // public void Eat(Food item)
        // {
        //     if(this.IsFull){
        //         Console.WriteLine("Ninja is Full");
        //     } else {
        //         calorieIntake += item.Calories;
        //         ConsumeFoodHistory.Add(item);
        //         Console.WriteLine("Food ninja ate: " + item.Name);
        //     }
        // }
    }
}