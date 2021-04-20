using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Player
    {
        public string Name{get;set;}
        public List<Card> typeCard{get; set;}

        public Player(string name){
            Name = name;
            typeCard = new List<Card>();
            Console.WriteLine($"Welcome, {Name}");
        }

        public Card Draw(Deck item)
        {
            Card taken = item.TopMost();
            this.typeCard.Add(taken);
            Console.WriteLine($"Player {this.Name} draws a card, gets {taken.StringVal} {taken.Suit}");
            return taken;
        }

        public Card Discard(int index)
        {
            if(index > typeCard.Count){
                return null;
            }
            Card temp = typeCard[index];
            this.typeCard.RemoveAt(index);
            // or
            // typeCard.Remove(temp);
            Console.WriteLine($"Player {this.Name} discard card {temp.StringVal} {temp.Suit}");
            return temp;
        }
    }
}