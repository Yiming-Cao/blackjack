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
        private bool isDealerSecondCardHidden; // 标记庄家的第二张牌是否隐藏
        private int currentDealRound = 0; // 用于判断发第几轮
        private int numberOfDecks = 1;
        public int? WinnerIndex { get; private set; } = null;  // 0-3 玩家，4 表示庄家
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

        // 发牌给庄家：第一张牌（明牌）
        public Card DealDealerFirstCard()
        {

            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);
            // 第一张牌为明牌
            isDealerSecondCardHidden = false;
            return card;

        }

        // 发牌给庄家：第二张牌（暗牌）
        public Card DealDealerSecondCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);
            // 第二张牌设置为隐藏
            isDealerSecondCardHidden = true;
            return card;

        }

        public Card DealExtraDealerCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            dealer.ReceiveCard(card);  // 发牌到庄家手上
            return card;
        }

        public void RestartGame()
        {
            // 重新初始化玩家和庄家的手牌
            foreach (var player in players)
            {
                player.ResetHand();  // 假设Player类有ClearHand方法，用于清空手牌 
            }
            dealer.ResetHand();  // 假设Dealer类有ClearHand方法，用于清空庄家手牌

            // 重置庄家的第二张牌是否隐藏
            isDealerSecondCardHidden = false;

            // 重置发牌轮数
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

        // 提供庄家手牌数
        public int DealerCardCount() => dealer.Hand.Count;

        // 让 UI 知道庄家第二张牌是否隐藏
        public bool IsDealerSecondCardHidden() => isDealerSecondCardHidden;


        public bool ShouldAdvanceRound()
        {
            return players.All(p => p.Hand.Count > currentDealRound);
        }

        public bool CanDealMore() => currentDealRound < 1;

        public void AdvanceRound() => currentDealRound++;

        // 🔹 触发游戏结束时翻开庄家的第二张牌
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

            bool anyPush = false;

            for (int i = 0; i < players.Length; i++)
            {
                int playerValue = players[i].GetHandValue();
                bool playerBust = playerValue > 21;

                if (playerBust)
                    continue;

                if (dealerBust || playerValue > dealerValue)
                {
                    winners.Add(i); // 玩家赢
                }
                else if (playerValue == dealerValue)
                {
                    anyPush = true; // 平局情况，暂不加 -1，避免混入多个判断
                }
            }

            // 如果没人赢但有平局
            if (winners.Count == 0 && anyPush)
            {
                winners.Add(-1); // 表示 Push 平局
            }

            // 如果没人赢没人平局，庄家赢（只有庄家没爆）
            if (winners.Count == 0 && !dealerBust)
            {
                winners.Add(4); //庄家赢
            }

            return winners.Distinct().ToList();
        }



    }
}
