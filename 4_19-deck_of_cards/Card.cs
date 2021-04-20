using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Card
    {
        public string StringVal{get;set;}
        public string Suit{get;set;}
        public int Val{get;set;}

        public Card(string stringVal, string suit, int val){
            StringVal = stringVal;
            Suit = suit;
            Val = val;
        }
    }
}