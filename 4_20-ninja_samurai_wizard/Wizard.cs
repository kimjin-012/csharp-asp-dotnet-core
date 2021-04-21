using System;

namespace wizard_ninja_samurai
{
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Name = name;
            Intelligence = 25;
            health = 50;
            Console.WriteLine($"Wizard {name} created- Inteligence of {Intelligence}");
            Console.WriteLine("***************NEXT**************");
        }

        public override int Attack(Human target)
        {
            int atk = this.Intelligence;
            target.health -= atk;
            this.health += atk;
            Console.WriteLine($"{this.Name} attacks {target.Name} with {atk} damage, now {target.Name} health is {target.health}");
            Console.WriteLine($"{this.Name} heals itself with {atk} points");
            if(this.health > 50){
                Console.WriteLine($"Overhealed applied, {this.Name} overhealed with {this.health - 50}, going back to 50 hp");
                this.health = 50;
            }
            Console.WriteLine($"{this.Name}, new health is now {this.health}");
            Console.WriteLine("***************NEXT**************");
            return target.health;
        }

        public void Heal(Human target)
        {
            target.health += this.Intelligence;
            Console.WriteLine($"{this.Name} heals {target.Name} recieves {this.Intelligence} healing points. {target.Name} helath is now {target.health}");
            Console.WriteLine("***************NEXT**************");
        }
    }
}

// , int strength, int intelligence, int dexterity, int hp