using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp1.classes
{
    public class Game
    {
        private Deck deck;
        private Player[] players;
        private Dealer dealer;
        private bool isDealerSecondCardHidden; // 标记庄家的第二张牌是否隐藏
        private int currentDealRound = 0; // 用于判断发第几轮

        public Game()
        {
            deck = new Deck();
            deck.Shuffle();

            players = new Player[4];
            for (int i = 0; i < 4; i++)
            {
                players[i] = new Player();
            }

            dealer = new Dealer();
        }

        public Dealer GetDealer() => dealer;
        public Player GetPlayer(int index) => players[index];

        public Card DealCardToPlayer(int index)
        {
            if (players[index].Hand.Count <= currentDealRound)
            {
                Card card = deck.DrawCard();
                players[index].ReceiveCard(card);
                return card;
            }
            return null; // 如果当前轮已经发了，就不再发
        }

        // 发牌给庄家：第一张牌（明牌）
        public Card DealDealerFirstCard()
        {
            if (dealer.Hand.Count == 0)
            {
                Card card = deck.DrawCard();
                dealer.ReceiveCard(card);
                // 第一张牌为明牌
                isDealerSecondCardHidden = false;
                return card;
            }
            return null;
        }

        // 发牌给庄家：第二张牌（暗牌）
        public Card DealDealerSecondCard()
        {
            if (dealer.Hand.Count == 1)
            {
                Card card = deck.DrawCard();
                dealer.ReceiveCard(card);
                // 第二张牌设置为隐藏
                isDealerSecondCardHidden = true;
                return card;
            }
            return null;
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
    }
}
