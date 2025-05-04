using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp1.classes
{
    public class Game
    {
        private List<Card> deck;
        private Player[] players;
        private Dealer dealer;
        private bool isDealerSecondCardHidden; 
        private int currentDealRound = 0; 
        private int numberOfDecks = 1;
        public int? WinnerIndex { get; private set; } = null;  
        public bool IsGameOver { get; private set; } = false;
        private List<int> winnerIndices = new List<int>();
        public Score ScoreSystem = new Score();
        



        public Game()
        {
            
            players = new Player[4];
            for (int i = 0; i < 4; i++)
            {
                players[i] = new Player();
            }

            dealer = new Dealer();
            ShuffleDeck(); // Ensure deck is initialized

        }

        public void SetDeckCount(int count)
        {
            numberOfDecks = count;
        }

        public void ShuffleDeck()
        {
            deck = Deck.GenerateMultipleDecks(numberOfDecks);
            var rng = new Random();
            deck = deck.OrderBy(_ => rng.Next()).ToList();
        }

        public Dealer GetDealer() => dealer;
        public Player GetPlayer(int index) => players[index];

        public Card DealCardToPlayer(int index, bool checkScoring = false)
        {
            int handValue = players[index].GetHandValue();

            if (deck.Count == 0)
                ShuffleDeck();

            Card card = deck[0];
            deck.RemoveAt(0);
            players[index].ReceiveCard(card);


            return card;
        }

        
        public Card DealDealerFirstCard()
        {

            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);
            
            isDealerSecondCardHidden = false;
            return card;

        }

        
        public Card DealDealerSecondCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);
            
            isDealerSecondCardHidden = true;
            return card;

        }

        public Card DealExtraDealerCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);  
            return card;
        }

        public void RestartGame()
        {
            
            foreach (var player in players)
            {
                player.ResetHand();   
            }
            dealer.ResetHand();  

            
            isDealerSecondCardHidden = false;

            
            currentDealRound = 0;

            ScoreSystem.IsFreeHitPhase = false;


        }

        public void SetMultipleWinners(List<int> indices)
        {
            winnerIndices = new List<int>(indices);
        }

        public string GetMultipleWinnerNames()
        {
            List<string> names = new List<string>();
            foreach (int i in winnerIndices)
            {
                if (i >= 0 && i < players.Length) // Corrected from players.Count to players.Length
                    names.Add($"Player {i + 1}");
                else if (i == players.Length) // Corrected from players.Count to players.Length
                    names.Add("Dealer");
            }

            return string.Join(" & ", names);
        }

        
        public int DealerCardCount() => dealer.Hand.Count;

        
        public bool IsDealerSecondCardHidden() => isDealerSecondCardHidden;


        public bool ShouldAdvanceRound()
        {
            return players.All(p => p.Hand.Count > currentDealRound);
        }

        public bool CanDealMore() => currentDealRound < 1;

        public void AdvanceRound() => currentDealRound++;

        
        public void RevealDealerCard() => isDealerSecondCardHidden = false;

        public bool AreAllPlayersDone()
        {
            foreach (var player in players)
            {
                int handValue = player.GetHandValue();
                if (handValue < 17 && !player.IsBust)
                    return false;
            }
            return true;
        }

        public List<int> GetRecommendedWinners()
        {
            List<int> winners = new List<int>();
            int dealerValue = dealer.GetHandValue();
            bool dealerBust = dealerValue > 21;

            for (int i = 0; i < players.Length; i++)
            {
                int playerValue = players[i].GetHandValue();
                bool playerBust = playerValue > 21;

                if (!playerBust)
                {
                    if (dealerBust || playerValue > dealerValue)
                    {
                        winners.Add(i); 
                    }
                    else if (playerValue == dealerValue)
                    {
                        
                        winners.Add(-1); 
                    }
                }
            }

            
            bool allPlayersLoseOrBust = players.All(p => p.GetHandValue() > 21 || (!dealerBust && p.GetHandValue() < dealerValue));
            if (allPlayersLoseOrBust && !dealerBust)
            {
                winners.Clear();
                winners.Add(4); 
            }

            return winners.Distinct().ToList();
        }





    }
}
