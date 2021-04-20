using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            Player newGuy = new Player("Jin");

            newDeck.TopMost();
            newDeck.Shuffle();
            // newDeck.Reset();
            newGuy.Draw(newDeck);
            newGuy.Discard(0);
        }
    }
}
