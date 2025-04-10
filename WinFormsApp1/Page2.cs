﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp1
{
    public partial class Page2 : UserControl
    {
        private Game game;
        private System.Windows.Forms.Timer shuffleTimer;
        private int shuffleFrame = 0;
        private PictureBox shuffleBox;
        private System.Windows.Forms.Timer decisionTimer;



        public Page2()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Page2_Load(object sender, EventArgs e)
        {
            decisionTimer = new System.Windows.Forms.Timer();
            decisionTimer.Interval = 2000;
            decisionTimer.Tick += DecisionTimer_Tick;

        }

        private void StartShuffleAnimation()
        {
            // 如果之前有图，就先移除  
            if (shuffleBox != null && this.Controls.Contains(shuffleBox))
                this.Controls.Remove(shuffleBox);

            // 创建一个显示牌背的 PictureBox  
            shuffleBox = new PictureBox
            {
                Size = new Size(80, 120),
                Location = new Point(Width / 2 - 40, Height / 2 - 60), // 居中  
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // 修复 CS0029 错误：将 byte[] 转换为 Image  
            using (MemoryStream ms = new MemoryStream(Properties.Resources.back_of_card))
            {
                shuffleBox.Image = Image.FromStream(ms);
            }

            this.Controls.Add(shuffleBox);
            shuffleBox.BringToFront();

            // 创建 Timer  
            shuffleFrame = 0;
            shuffleTimer = new System.Windows.Forms.Timer();
            shuffleTimer.Interval = 50; // 每 50ms 一帧  
            shuffleTimer.Tick += ShuffleTimer_Tick;
            shuffleTimer.Start();
        }

        private void ShuffleTimer_Tick(object sender, EventArgs e)
        {
            shuffleFrame++;

            // 每次 Tick 可以稍微改变位置/角度来制造“在洗”的感觉
            shuffleBox.Left = this.Width / 2 - 40 + (shuffleFrame % 2 == 0 ? -5 : 5);
            shuffleBox.Top = this.Height / 2 - 60 + (shuffleFrame % 3 - 1) * 3;

            if (shuffleFrame > 20) // 播放 20 帧左右
            {
                shuffleTimer.Stop();
                shuffleTimer.Dispose();
                this.Controls.Remove(shuffleBox); // 动画结束，移除
                shuffleBox.Dispose();
            }
        }

        private void DealToPlayer(int index, Panel panel)
        {

            HidePlayerDecision(index);

            Card dealtCard = game.DealCardToPlayer(index);

            if (dealtCard != null)
            {
                ShowCardInPanel(dealtCard, panel, game.GetPlayer(index).Hand.Count - 1);
            }

            if (AllPlayersAndDealerHaveTwoCards())
            {
                decisionTimer.Start(); // 开始计时，2 秒后触发气泡
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

                // ✅ 添加这个判断
                if (AllPlayersAndDealerHaveTwoCards())
                {
                    decisionTimer.Start(); // 所有人都有两张牌了，开始显示 Hit/Stand
                }
            }
            else
            {
                // ✅ 第三张及之后的牌为明牌
                Card c = game.DealExtraDealerCard();
                if (c != null)
                    ShowCardInPanel(c, panelDealerCards, dealerCount);
            }
        }

        private void buttonShowDealerCard_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelDealerCards.Controls)
            {
                if (ctrl is PictureBox pb && pb.Tag is Card card)
                {
                    // 找到有 Card 的 PictureBox（暗牌），显示出来
                    MessageBox.Show($"Hidden card is：{card}");
                    return;
                }
            }

            MessageBox.Show("No Hidden Card !!");
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            StartShuffleAnimation(); // 播放动画
            game.ShuffleDeck();      // 执行洗牌逻辑
        }

        private void ShowPlayerDecision(int index, string message)
        {
            Label targetLabel = index switch
            {
                0 => labelPlayer1Bubble,
                1 => labelPlayer2Bubble,
                2 => labelPlayer3Bubble,
                3 => labelPlayer4Bubble,
                _ => null
            };

            if (targetLabel != null)
            {
                targetLabel.Text = message;
                targetLabel.Visible = true;
                targetLabel.BringToFront();

            }
        }


        private void HidePlayerDecision(int index)
        {
            Label targetLabel = index switch
            {
                0 => labelPlayer1Bubble,
                1 => labelPlayer2Bubble,
                2 => labelPlayer3Bubble,
                3 => labelPlayer4Bubble,
                _ => null
            };

            if (targetLabel != null)
            {
                targetLabel.Visible = false;
            }
        }



        private bool AllPlayersAndDealerHaveTwoCards()
        {
            for (int i = 0; i < 4; i++)
            {
                if (game.GetPlayer(i).Hand.Count != 2)
                    return false;
            }

            if (game.GetDealer().Hand.Count != 2) // Fixed the issue by calling the method instead of treating it as a method group
                return false;

            return true;
        }

        private void DecisionTimer_Tick(object sender, EventArgs e)
        {
            decisionTimer.Stop(); // 停止定时器，防止重复触发

            for (int i = 0; i < 4; i++)
            {
                int total = game.GetPlayer(i).Hand.Sum(card => card.Value);
                string decision = total < 17 ? "Hit" : "Stand";
                ShowPlayerDecision(i, decision); // 你之前已有这个方法
            }
        }

    }
}
