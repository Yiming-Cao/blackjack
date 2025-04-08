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

        private void DealToPlayer(int index, Panel panel)
        {
            Card dealtCard = game.DealCardToPlayer(index);

            if (dealtCard != null)
            {
                ShowCardInPanel(dealtCard, panel, game.GetPlayer(index).Hand.Count - 1);
            }

            if (game.ShouldAdvanceRound() && game.CanDealMore())
            {
                game.AdvanceRound();
                MessageBox.Show("进入下一轮发牌！");
            }
            else if (game.ShouldAdvanceRound() && !game.CanDealMore())
            {
                MessageBox.Show("所有玩家已发完 2 张牌，请为庄家发牌！");
            }
        }

        private void ShowCardInPanel(Card card, Panel panel, int index)
        {
            PictureBox pb = new PictureBox
            {
                Image = card.Img,
                Size = new Size(70, panel.Height),
                Location = new Point(20 * index, 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panel.Controls.Add(pb);
            pb.BringToFront();
        }

        private void ShowHiddenCardInPanel(Card card, Panel panel, int index)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(70, panel.Height),
                Location = new Point(20 * index, 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            // 使用牌背图片
            using (MemoryStream ms = new MemoryStream(Properties.Resources.back_of_card))
            {
                pb.Image = Image.FromStream(ms);
            }
            pb.Tag = card;  // 存储真实的牌
            panel.Controls.Add(pb);
            pb.BringToFront();
        }

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

        private void buttonDeal1_Click(object sender, EventArgs e)
        {
            DealToPlayer(0, panelPlayer1Cards);
        }

        private void buttonDeal2_Click(object sender, EventArgs e)
        {
            DealToPlayer(1, panelPlayer2Cards);
        }

        private void buttonDeal3_Click(object sender, EventArgs e)
        {
            DealToPlayer(2, panelPlayer3Cards);
        }

        private void buttonDeal4_Click(object sender, EventArgs e)
        {
            DealToPlayer(3, panelPlayer4Cards);
        }

        private void buttonDealDealer_Click(object sender, EventArgs e)
        {
            int dealerCount = game.DealerCardCount();
            if (dealerCount == 0)
            {
                // 发庄家第一张牌（明牌）
                Card c = game.DealDealerFirstCard();
                if (c != null)
                    ShowCardInPanel(c, panelDealerCards, 0);
            }
            else if (dealerCount == 1)
            {
                // 发庄家第二张牌（暗牌），隐藏状态
                Card c = game.DealDealerSecondCard();
                if (c != null)
                    ShowHiddenCardInPanel(c, panelDealerCards, 1);
                MessageBox.Show("庄家发完两张牌！");
            }
            else
            {
                MessageBox.Show("庄家已发完牌！");
            }
        }

        private void buttonShowDealerCard_Click(object sender, EventArgs e)
        {
            if (panelDealerCards.Controls.Count > 1)
            {
                PictureBox secondCard = panelDealerCards.Controls[1] as PictureBox;
                if (secondCard != null && secondCard.Tag is Card realCard)
                {
                    MessageBox.Show($"庄家的暗牌是：{realCard.ToString()}");
                }
                else
                {
                    MessageBox.Show("找不到庄家的暗牌！");
                }
            }
            else
            {
                MessageBox.Show("庄家还没发第二张牌！");
            }
        }
    }
}
