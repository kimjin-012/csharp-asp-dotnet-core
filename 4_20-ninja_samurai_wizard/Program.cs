using System;

namespace wizard_ninja_samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Harry = new Wizard("Harry");
            Ninja Jin = new Ninja("Jin");
            Samurai Genji = new Samurai("Genji");

            Harry.Attack(Genji);
            Jin.Attack(Genji);
            Jin.Attack(Harry);
            Genji.Attack(Jin);

            Harry.Heal(Jin);
            Genji.Meditate();
            Jin.Steal(Genji);
        }
    }
}
