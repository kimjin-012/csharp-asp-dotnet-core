using System;

namespace phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia eleven = new Nokia("1100", 60, "Metro", "Rrrringggg rrrrrriiiinnggg");
            Galaxy s21 = new Galaxy("s21", 29, "T-Mobie", "Doo Doo Doo Doooo");

            eleven.DisplayInfo();
            Console.WriteLine(eleven.Ring());
            Console.WriteLine(eleven.Unlock());
            Console.WriteLine("");

            s21.DisplayInfo();
            Console.WriteLine(s21.Ring());
            Console.WriteLine(s21.Unlock());
            Console.WriteLine("");
        }
    }
}
