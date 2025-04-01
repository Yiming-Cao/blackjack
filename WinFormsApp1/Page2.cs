using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.classes;

namespace WinFormsApp1
{
    public partial class Page2 : UserControl
    {
        private Game game;

        public Page2()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Page2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false; // 隐藏 "Go" 按钮
            game.StartGame();
            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.PlayerStand(this); // 传递当前 UI 界面
            UpdateUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bet placed!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.PlayerHit(this);
            UpdateUI();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 这里实现 "投降" 按钮
            MessageBox.Show("You surrendered!");
            game.StartGame();
            UpdateUI();
        }

        public void DisableHitButton() => button4.Enabled = false;
        public void EnableHitButton() => button4.Enabled = true;
        public void DisableAllButtons()
        {
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
        }

        public void EnableAllButtons()
        {
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
        }


        /// <summary>
        /// 更新 UI 牌面
        /// </summary>
        private void UpdateUI()
        {
            panelPlayerCards.Controls.Clear();
            panelDealerCards.Controls.Clear();

            int playerOffset = 0;
            int dealerOffset = 0;
            int cardWidth = 70;
            int cardHeight = panelPlayerCards.Height;

            List<Card> dealerCards = game.GetDealerCard();
            List<Card> playerCards = game.GetPlayerCard();
            bool hideDealerCard = game.IsDealerSecondCardHidden(); // 读取游戏状态

            // 显示玩家的手牌
            foreach (Card card in playerCards)
            {
                PictureBox pb = new PictureBox
                {
                    Image = card.Img,
                    Size = new Size(cardWidth, cardHeight),
                    Location = new Point(playerOffset, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                panelPlayerCards.Controls.Add(pb);
                pb.BringToFront();
                playerOffset += 20;
            }

            // 显示庄家的手牌
            for (int i = 0; i < dealerCards.Count; i++)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(cardWidth, cardHeight),
                    Location = new Point(dealerOffset, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (i == 1 && hideDealerCard)
                {
                    using (MemoryStream ms = new MemoryStream(Properties.Resources.back_of_card))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                    pb.Tag = dealerCards[i];
                }
                else
                {
                    pb.Image = dealerCards[i].Img;
                }

                panelDealerCards.Controls.Add(pb);
                pb.BringToFront();
                dealerOffset += 20;
            }
        }


        /// <summary>
        /// 游戏结束时翻开庄家的第二张牌
        /// </summary>
        public void RevealDealerCard()
        {
            if (panelDealerCards.Controls.Count > 1)
            {
                PictureBox secondCard = panelDealerCards.Controls[1] as PictureBox;
                if (secondCard != null && secondCard.Tag is Card realCard)
                {
                    secondCard.Image = realCard.Img;  // 还原真实的牌
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            game.StartGame();
            UpdateUI();
            EnableAllButtons();
        }


    }
}
