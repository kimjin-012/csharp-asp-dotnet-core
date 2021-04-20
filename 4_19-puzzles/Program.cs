using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TossMultipleCoins(5));
        }
        public static int[] RandomArray()
        {
            Random rand = new Random();
            List<int> randInt = new List<int>();
            for(int i=0; i<10; i++){
                int num = rand.Next(5, 25);
                randInt.Add(num);
            }

            int[] results = randInt.ToArray();
            Console.WriteLine(results.Max());
            Console.WriteLine(results.Min());

            int sum = 0;
            foreach(int num in results){
                sum += num;
            }
            Console.WriteLine(sum);
            return results;
        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int side = rand.Next(0,2);
            string coin = "";
            if(side == 0){
                Console.WriteLine("Heads");
                coin = "Heads";
            } else {
                Console.WriteLine("Tails");
                coin = "Tails";
            }

            return coin;
        }

        public static double TossMultipleCoins(int num)
        {
            double heads = 0;
            double tails = 0;
            for(int i=0; i<num; i++){
                if(TossCoin() == "Heads"){
                    heads++;
                } else {
                    tails++;
                }
            }
            if(tails == 0){
                tails = 1;
            }
            return heads/tails;
        }

        public static List<string> Names()
        {
            List<string> nameList = new List<string> {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            List<string> longerNameList = new List<string>();
            for(int i=0; i<nameList.Count; i++){
                Random r = new Random();
                int rand = r.Next(0, nameList.Count);

                string temp = nameList[i];
                nameList[i] = nameList[rand];
                nameList[rand] = temp;
            }
            foreach(string name in nameList){
                if(name.Length > 5){
                    longerNameList.Add(name);
                }
            }

            Console.WriteLine(String.Join(",", nameList));
            Console.WriteLine(String.Join(",", longerNameList));

            // or
            // return longerNameList.Where(name => name.Length > 5).ToList();

            return longerNameList;
        }
    }
}
