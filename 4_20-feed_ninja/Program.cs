using System;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet Store = new Buffet();
            SweetTooth MyMouth = new SweetTooth();
            SpiceHound MyStomache = new SpiceHound();

            while(!MyMouth.IsFull){
                MyMouth.Consume(Store.Serve());
            }
            while(!MyStomache.IsFull){
                MyStomache.Consume(Store.Serve());
            }
            if(MyMouth.ConsumeFoodHistory.Count > MyStomache.ConsumeFoodHistory.Count){
                Console.WriteLine($"Teeth are having some problem from all that sweets, you ate {MyMouth.ConsumeFoodHistory.Count}");
            } else {
                Console.WriteLine($"Stomache are having some problem from all that spices, you ate {MyStomache.ConsumeFoodHistory.Count}");
            }
        }
    }
}
