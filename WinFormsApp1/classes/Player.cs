using System.Collections.Generic;

namespace WinFormsApp1.classes
{
    public class Player
    {
        public List<Card> Hand { get; private set; }
        public int Score => CalculateScore();
        public bool IsBust => Score > 21;

        public Player()
        {
            Hand = new List<Card>();
        }

        public void ResetHand()
        {
            Hand.Clear();
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
            AdjustAceValue();
        }

        private int CalculateScore()
        {
            int total = 0;
            foreach (var card in Hand)
            {
                total += card.Value;
            }
            return total;
        }

        private void AdjustAceValue()
        {
            if (Score > 21)
            {
                foreach (var card in Hand)
                {
                    if (card.FaceValue == FaceValues.ACE && card.Value == 11)
                    {
                        card.SetAceValueToOne();
                        break;
                    }
                }
            }
        }
    }
}
