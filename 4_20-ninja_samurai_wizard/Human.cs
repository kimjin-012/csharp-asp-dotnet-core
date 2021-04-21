using System;

namespace wizard_ninja_samurai{

    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        // protected
        public int health;
        public int Health
        {
            get { return health;}
        }

        // public string Name {get;set;}
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
            // Console.WriteLine($"human {Name} created- S:{Strength}, I:{Intelligence}, D:{Dexterity}, H:{health}");
        }
        public Human(string name, int strenght, int intelligence, int dexterity, int hp)
        {
            Name = name;
            Strength = strenght;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = hp;
            // Console.WriteLine($"human {Name} created- S:{Strength}, I:{Intelligence}, D:{Dexterity}, H:{health}");
        }
        public virtual int Attack(Human target)
        {
            target.health -= this.Strength * 5;
            Console.WriteLine($"{this.Name} attacks {target.Name} with {this.Strength * 5} damage, now {target.Name} health is {target.health}");
            return target.health;
        }
    }
}