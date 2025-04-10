using System;
using System.Collections.Generic;

namespace WinFormsApp1.classes
{
    public class Deck
    {
        private List<Card> cards;
        private Random rand;

        public Deck()
        {
            cards = new List<Card>();
            rand = new Random();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            cards = GenerateStandardDeck();

        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]); // 交换位置
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                InitializeDeck();
                Shuffle();
            }

            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }

        // ✅ 静态方法：生成一副标准 52 张牌
        public static List<Card> GenerateStandardDeck()
        {
            List<Card> singleDeck = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (FaceValues faceValue in Enum.GetValues(typeof(FaceValues)))
                {
                    singleDeck.Add(new Card(suit, faceValue));
                }
            }
            return singleDeck;
        }

        public static List<Card> GenerateMultipleDecks(int count)
        {
            List<Card> combined = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                combined.AddRange(GenerateStandardDeck());
            }
            return combined;
        }
    }
}
