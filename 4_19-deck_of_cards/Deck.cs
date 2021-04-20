using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Deck
    {
        public List<Card> cards{get;set;}

        public List<string> exstringVal = new List<string> 
        {"Ace", "2", "3", "4", "5", "6", "7",
        "8", "9", "10", "Jack", "Queen", "King"};
        public List<string> exsuit = new List<string> {
            "Clubs", "Spades", "Hearts", "Diamonds"
        };
        public List<int> exval = new List<int> {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
        };

        public Deck()
        {
            Console.WriteLine("Decks are ready");
            Init();
        }

        public void Init(){
            cards = new List<Card>() {};
            foreach(int val in exval){
                string name = exstringVal[val - 1];
                foreach(string shape in exsuit){
                        Card rand = new Card(name, shape, val);
                        cards.Add(rand);
                }
            }
        }
        public Card TopMost()
        {
            Card top_most = cards[0];
            Console.WriteLine($"Top Card was: {top_most.StringVal} w {top_most.Suit} n {top_most.Val}");
            return top_most;
        }

        public void Reset(){
            Console.WriteLine("Decks are Reset");
            Init();
        }

        public void Shuffle()
        {
            for(int i=0; i<cards.Count; i++){
                Random r = new Random();
                int rand = r.Next(0, cards.Count);

                Card temp = cards[i];
                cards[i] = cards[rand];
                cards[rand] = temp;
            }
            Console.WriteLine("Cards are shuffled");
        }
    }
}