using System;
using System.Collections.Generic;
using System.Linq;

namespace basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers();
        }

        public static void PrintNumbers()
        {
            for(int i=1; i<256; i++){
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for(int i=1; i<256; i++){
                if(i%2==1){
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintSum()
        {
            int allSum = 0;
            for(int i=1; i<256; i++){
                Console.WriteLine(i);
                allSum += i;
                Console.WriteLine(allSum);
            }
        }

        public static void LoopArray(int[] numbers)
        {
            foreach(var item in numbers){
                Console.WriteLine(item);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int maxVal = numbers.Max();
            return maxVal;
        }

        public static int GetAverage(int[] numbers)
        {
            int sum = numbers.Sum();
            Console.WriteLine(sum/numbers.Length);
            return sum;
        }

        public static int[] OddArray()
        {
            // List<int> exOdd = new List<int>();
            int[] exOdd = new int[] {};
            for(int i=1; i<256; i++){
                if(i%2==1){
                    var exOddList = exOdd.ToList();
                    exOddList.Add(i);
                    exOdd = exOddList.ToArray();
                }
            }
            return exOdd;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int greater = 0;
            foreach(int i in numbers){
                if(i > y){
                    greater++;
                }
            }
            return greater;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            List<int> exTemp = new List<int>();
            foreach(int i in numbers){
                exTemp.Add(i*i);
            }
            int[] result = exTemp.ToArray();
            Console.WriteLine(result);
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int max = FindMax(numbers);
            int average = GetAverage(numbers);
            int min = numbers.Min();

            Console.WriteLine("maximum: " + max + ", minimum: " + min + ", average: " + average);
        }

        public static void ShiftValues(int[] numbers)
        {
            List<int> exTemp = new List<int>();
            for(int i=1; i<numbers.Length; i++){
                exTemp.Add(numbers[i]);
            }
            exTemp.Add(0);
            int[] result = exTemp.ToArray();
            Console.WriteLine(result);
        }

        public static object[] NumToString(int[] numbers)
        {
            List<object> exTemp = new List<object>();
            foreach(int i in numbers){
                if(i < 0){
                    exTemp.Add("Dojo");
                } else {
                    exTemp.Add(i);
                }
            }
            object[] result = exTemp.ToArray();
            return result;
        }
    }
}
