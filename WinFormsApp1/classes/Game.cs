using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp1.classes
{
    public class Game
    {
        private Deck deck;
        private Player player;
        private Dealer dealer;
        private bool isDealerSecondCardHidden; // 标记庄家的第二张牌是否隐藏

        public Game()
        {
            deck = new Deck();
            player = new Player();
            dealer = new Dealer();
        }

        public void StartGame()
        {
            deck.Shuffle();
            player.ResetHand();
            dealer.ResetHand();
            isDealerSecondCardHidden = true; // 游戏开始时隐藏庄家第二张牌

            // 初始发牌
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());

        }

        public void PlayerHit(Page2 page)
        {
            page.DisableHitButton(); // 禁用 Hit 按钮

            // 玩家抽一张牌
            Card newCard = deck.DrawCard();
            player.ReceiveCard(newCard);
            

            // 检查玩家是否爆牌
            if (player.IsBust)
            {
                MessageBox.Show("Player Busts! Dealer Wins!");
                RevealDealerCard();
                EndGame(page);
                return;
            }

            // 庄家回合：若小于 17 点，则自动要牌
            while (dealer.Score < 17)
            {
                Card dealerCard = deck.DrawCard();
                dealer.ReceiveCard(dealerCard);
                
            }

            // 检查庄家是否爆牌
            if (dealer.IsBust)
            {
                MessageBox.Show("Dealer Busts! Player Wins!");
                RevealDealerCard();
                EndGame(page);
                return;
            }

            page.EnableHitButton(); // 重新启用 Hit 按钮
        }

        public void PlayerStand(Page2 ui)
        {
            // 1. 翻开庄家的第二张牌
            RevealDealerCard();

            // 2. 让庄家进行回合（自动补牌，直到 >= 17 或者爆牌）
            DealerTurn(ui);

            // 4. 结束游戏，禁用按钮
            EndGame(ui);
        }

        // 结束游戏逻辑
        private void EndGame(Page2 ui)
        {
            ui.DisableAllButtons(); // 统一禁用所有操作按钮
            RevealDealerCard();
            string result = GetWinner();
            MessageBox.Show(result);
        }



        public void DealerTurn(Page2 ui)
        {
            while (dealer.Score < 17)  // 庄家必须抽牌，直到 17 分或以上
            {
                Card dealerCard = deck.DrawCard();
                dealer.ReceiveCard(dealerCard);
                // 更新 UI，显示庄家的新牌

                // 如果庄家爆牌，直接结束
                if (dealer.IsBust)
                {
                    MessageBox.Show("Dealer Busts! Player Wins!");
                    return;
                }
            }
        }

        public string GetWinner()
        {
            if (player.IsBust) return "Dealer Wins!";
            if (dealer.IsBust) return "Player Wins!";
            if (player.Score > dealer.Score) return "Player Wins!";
            if (player.Score < dealer.Score) return "Dealer Wins!";
            return "It's a Tie!";
        }

        public List<Card> GetPlayerCard() => player.Hand;
        public List<Card> GetDealerCard() => dealer.Hand;

        // 🔹 让 UI 知道庄家的第二张牌应该被隐藏
        public bool IsDealerSecondCardHidden() => isDealerSecondCardHidden;

        // 🔹 触发游戏结束时翻开庄家的第二张牌
        public void RevealDealerCard() => isDealerSecondCardHidden = false;
    }
}
