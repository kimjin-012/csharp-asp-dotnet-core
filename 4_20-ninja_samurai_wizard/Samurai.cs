using System;

namespace wizard_ninja_samurai
{
    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
            Console.WriteLine($"Samurai {name} created- health of {health}");
            Console.WriteLine("***************NEXT**************");
        }
        public override int Attack(Human target)
        {   
            base.Attack(target);
            if(target.health < 50){
                target.health = 0;
                Console.WriteLine($"{target.Name} only has {target.health} health, so it recieved Samurai {this.Name} finishing blow, and died");
            }
            Console.WriteLine("***************NEXT**************");
            return target.health;
        }

        public void Meditate()
        {
            this.health = 200;
            Console.WriteLine($"Samurai {this.Name} uses Meditate, heals back this health to 200");
            Console.WriteLine("***************NEXT**************");
        }
    }
}