using System;

namespace wizard_ninja_samurai
{
    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 75;
            Console.WriteLine($"Ninja {name} created- Dexterity of {Dexterity}");
            Console.WriteLine("***************NEXT**************");
        }

        public override int Attack(Human target)
        {
            Random r = new Random();
            int chance = r.Next(1, 5);
            int atk = this.Dexterity;
            if(chance == 5){
                atk += 10;
            };
            target.health -= atk;
            Console.WriteLine($"{this.Name} attacks {target.Name} with {atk} damage, now {target.Name} health is {target.health}");
            Console.WriteLine("***************NEXT**************");
            return target.health;
        }

        public void Steal(Human target)
        {
            target.health -= 5;
            this.health += 5;
            Console.WriteLine($"{this.Name} uses Steal, and take 5 health from {target.Name}");
            Console.WriteLine("***************NEXT**************");
        }
    }
}