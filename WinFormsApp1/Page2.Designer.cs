﻿namespace WinFormsApp1
{
    partial class Page2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page2));
            pictureBox1 = new PictureBox();
            buttonShuffle = new Button();
            buttonWinnerDealer = new Button();
            buttonSet = new Button();
            panelPlayer2Cards = new Panel();
            panelDealerCards = new Panel();
            RestartButton = new Button();
            Deck2Button = new Button();
            Deck1Button = new Button();
            panelPlayer3Cards = new Panel();
            panelPlayer1Cards = new Panel();
            panelPlayer4Cards = new Panel();
            buttonDeal1 = new Button();
            buttonDeal2 = new Button();
            buttonDeal3 = new Button();
            buttonDeal4 = new Button();
            buttonDealDealer = new Button();
            buttonShowDealerCard = new Button();
            timerShuffle = new System.Windows.Forms.Timer(components);
            labelPlayer1Bubble = new Label();
            labelPlayer2Bubble = new Label();
            labelPlayer3Bubble = new Label();
            labelPlayer4Bubble = new Label();
            buttonWinner1 = new Button();
            buttonWinner2 = new Button();
            buttonWinner3 = new Button();
            buttonWinner4 = new Button();
            labelScore1 = new Label();
            labelScore2 = new Label();
            labelScore3 = new Label();
            labelScore4 = new Label();
            labelScoreDealer = new Label();
            buttonPush = new Button();
            buttonConfirmWinners = new Button();
            labelScore = new Label();
            labelTip = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(714, 402);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonShuffle
            // 
            buttonShuffle.Location = new Point(29, 418);
            buttonShuffle.Name = "buttonShuffle";
            buttonShuffle.Size = new Size(92, 49);
            buttonShuffle.TabIndex = 5;
            buttonShuffle.Text = "Shuffle";
            buttonShuffle.UseVisualStyleBackColor = true;
            buttonShuffle.Click += buttonShuffle_Click;
            // 
            // buttonWinnerDealer
            // 
            buttonWinnerDealer.Location = new Point(282, 418);
            buttonWinnerDealer.Name = "buttonWinnerDealer";
            buttonWinnerDealer.Size = new Size(77, 49);
            buttonWinnerDealer.TabIndex = 7;
            buttonWinnerDealer.Text = "Dealer Win";
            buttonWinnerDealer.UseVisualStyleBackColor = true;
            buttonWinnerDealer.Visible = false;
            buttonWinnerDealer.Click += buttonWinnerDealer_Click;
            // 
            // buttonSet
            // 
            buttonSet.Location = new Point(495, 418);
            buttonSet.Name = "buttonSet";
            buttonSet.Size = new Size(92, 49);
            buttonSet.TabIndex = 8;
            buttonSet.Text = "Set Winner";
            buttonSet.UseVisualStyleBackColor = true;
            buttonSet.Click += buttonSet_Click;
            // 
            // panelPlayer2Cards
            // 
            panelPlayer2Cards.BackColor = Color.Transparent;
            panelPlayer2Cards.BackgroundImage = (Image)resources.GetObject("panelPlayer2Cards.BackgroundImage");
            panelPlayer2Cards.BackgroundImageLayout = ImageLayout.Center;
            panelPlayer2Cards.Location = new Point(201, 38);
            panelPlayer2Cards.Name = "panelPlayer2Cards";
            panelPlayer2Cards.RightToLeft = RightToLeft.No;
            panelPlayer2Cards.Size = new Size(144, 91);
            panelPlayer2Cards.TabIndex = 9;
            // 
            // panelDealerCards
            // 
            panelDealerCards.BackColor = Color.Transparent;
            panelDealerCards.BackgroundImage = (Image)resources.GetObject("panelDealerCards.BackgroundImage");
            panelDealerCards.Location = new Point(268, 272);
            panelDealerCards.Name = "panelDealerCards";
            panelDealerCards.Size = new Size(200, 100);
            panelDealerCards.TabIndex = 0;
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(607, 418);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(92, 49);
            RestartButton.TabIndex = 10;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // Deck2Button
            // 
            Deck2Button.Location = new Point(592, 353);
            Deck2Button.Name = "Deck2Button";
            Deck2Button.Size = new Size(92, 34);
            Deck2Button.TabIndex = 11;
            Deck2Button.Text = "2 deck";
            Deck2Button.UseVisualStyleBackColor = true;
            Deck2Button.Click += Deck2Button_Click;
            // 
            // Deck1Button
            // 
            Deck1Button.Location = new Point(592, 312);
            Deck1Button.Name = "Deck1Button";
            Deck1Button.Size = new Size(92, 35);
            Deck1Button.TabIndex = 12;
            Deck1Button.Text = "1 deck";
            Deck1Button.UseVisualStyleBackColor = true;
            Deck1Button.Click += Deck1Button_Click;
            // 
            // panelPlayer3Cards
            // 
            panelPlayer3Cards.BackColor = Color.Transparent;
            panelPlayer3Cards.BackgroundImage = (Image)resources.GetObject("panelPlayer3Cards.BackgroundImage");
            panelPlayer3Cards.BackgroundImageLayout = ImageLayout.Center;
            panelPlayer3Cards.Location = new Point(377, 38);
            panelPlayer3Cards.Name = "panelPlayer3Cards";
            panelPlayer3Cards.RightToLeft = RightToLeft.No;
            panelPlayer3Cards.Size = new Size(144, 92);
            panelPlayer3Cards.TabIndex = 13;
            // 
            // panelPlayer1Cards
            // 
            panelPlayer1Cards.BackColor = Color.Transparent;
            panelPlayer1Cards.BackgroundImage = (Image)resources.GetObject("panelPlayer1Cards.BackgroundImage");
            panelPlayer1Cards.BackgroundImageLayout = ImageLayout.Center;
            panelPlayer1Cards.Location = new Point(54, 151);
            panelPlayer1Cards.Name = "panelPlayer1Cards";
            panelPlayer1Cards.RightToLeft = RightToLeft.No;
            panelPlayer1Cards.Size = new Size(144, 91);
            panelPlayer1Cards.TabIndex = 14;
            // 
            // panelPlayer4Cards
            // 
            panelPlayer4Cards.BackColor = Color.Transparent;
            panelPlayer4Cards.BackgroundImage = (Image)resources.GetObject("panelPlayer4Cards.BackgroundImage");
            panelPlayer4Cards.BackgroundImageLayout = ImageLayout.Center;
            panelPlayer4Cards.Location = new Point(516, 151);
            panelPlayer4Cards.Name = "panelPlayer4Cards";
            panelPlayer4Cards.RightToLeft = RightToLeft.No;
            panelPlayer4Cards.Size = new Size(144, 91);
            panelPlayer4Cards.TabIndex = 15;
            // 
            // buttonDeal1
            // 
            buttonDeal1.Location = new Point(54, 248);
            buttonDeal1.Name = "buttonDeal1";
            buttonDeal1.Size = new Size(75, 23);
            buttonDeal1.TabIndex = 16;
            buttonDeal1.Text = "Deal1";
            buttonDeal1.UseVisualStyleBackColor = true;
            buttonDeal1.Click += buttonDeal1_Click;
            // 
            // buttonDeal2
            // 
            buttonDeal2.Location = new Point(201, 136);
            buttonDeal2.Name = "buttonDeal2";
            buttonDeal2.Size = new Size(75, 23);
            buttonDeal2.TabIndex = 17;
            buttonDeal2.Text = "Deal2";
            buttonDeal2.UseVisualStyleBackColor = true;
            buttonDeal2.Click += buttonDeal2_Click;
            // 
            // buttonDeal3
            // 
            buttonDeal3.Location = new Point(377, 136);
            buttonDeal3.Name = "buttonDeal3";
            buttonDeal3.Size = new Size(75, 23);
            buttonDeal3.TabIndex = 18;
            buttonDeal3.Text = "Deal3";
            buttonDeal3.UseVisualStyleBackColor = true;
            buttonDeal3.Click += buttonDeal3_Click;
            // 
            // buttonDeal4
            // 
            buttonDeal4.Location = new Point(516, 248);
            buttonDeal4.Name = "buttonDeal4";
            buttonDeal4.Size = new Size(75, 23);
            buttonDeal4.TabIndex = 19;
            buttonDeal4.Text = "Deal4";
            buttonDeal4.UseVisualStyleBackColor = true;
            buttonDeal4.Click += buttonDeal4_Click;
            // 
            // buttonDealDealer
            // 
            buttonDealDealer.Location = new Point(326, 378);
            buttonDealDealer.Name = "buttonDealDealer";
            buttonDealDealer.Size = new Size(75, 23);
            buttonDealDealer.TabIndex = 20;
            buttonDealDealer.Text = "DealDealer";
            buttonDealDealer.UseVisualStyleBackColor = true;
            buttonDealDealer.Click += buttonDealDealer_Click;
            // 
            // buttonShowDealerCard
            // 
            buttonShowDealerCard.Location = new Point(145, 418);
            buttonShowDealerCard.Name = "buttonShowDealerCard";
            buttonShowDealerCard.Size = new Size(92, 49);
            buttonShowDealerCard.TabIndex = 21;
            buttonShowDealerCard.Text = "SeeDealerCard";
            buttonShowDealerCard.UseVisualStyleBackColor = true;
            buttonShowDealerCard.Click += buttonShowDealerCard_Click;
            // 
            // labelPlayer1Bubble
            // 
            labelPlayer1Bubble.AutoSize = true;
            labelPlayer1Bubble.Location = new Point(68, 133);
            labelPlayer1Bubble.Name = "labelPlayer1Bubble";
            labelPlayer1Bubble.Size = new Size(38, 15);
            labelPlayer1Bubble.TabIndex = 22;
            labelPlayer1Bubble.Text = "label1";
            labelPlayer1Bubble.Visible = false;
            // 
            // labelPlayer2Bubble
            // 
            labelPlayer2Bubble.AutoSize = true;
            labelPlayer2Bubble.Location = new Point(217, 20);
            labelPlayer2Bubble.Name = "labelPlayer2Bubble";
            labelPlayer2Bubble.Size = new Size(38, 15);
            labelPlayer2Bubble.TabIndex = 23;
            labelPlayer2Bubble.Text = "label2";
            labelPlayer2Bubble.Visible = false;
            // 
            // labelPlayer3Bubble
            // 
            labelPlayer3Bubble.AutoSize = true;
            labelPlayer3Bubble.Location = new Point(389, 20);
            labelPlayer3Bubble.Name = "labelPlayer3Bubble";
            labelPlayer3Bubble.Size = new Size(38, 15);
            labelPlayer3Bubble.TabIndex = 24;
            labelPlayer3Bubble.Text = "label3";
            labelPlayer3Bubble.Visible = false;
            // 
            // labelPlayer4Bubble
            // 
            labelPlayer4Bubble.AutoSize = true;
            labelPlayer4Bubble.Location = new Point(527, 133);
            labelPlayer4Bubble.Name = "labelPlayer4Bubble";
            labelPlayer4Bubble.Size = new Size(38, 15);
            labelPlayer4Bubble.TabIndex = 25;
            labelPlayer4Bubble.Text = "label4";
            labelPlayer4Bubble.Visible = false;
            // 
            // buttonWinner1
            // 
            buttonWinner1.Location = new Point(135, 248);
            buttonWinner1.Name = "buttonWinner1";
            buttonWinner1.Size = new Size(47, 23);
            buttonWinner1.TabIndex = 26;
            buttonWinner1.Text = "Win";
            buttonWinner1.UseVisualStyleBackColor = true;
            buttonWinner1.Visible = false;
            buttonWinner1.Click += buttonWinner1_Click;
            // 
            // buttonWinner2
            // 
            buttonWinner2.Location = new Point(282, 135);
            buttonWinner2.Name = "buttonWinner2";
            buttonWinner2.Size = new Size(50, 23);
            buttonWinner2.TabIndex = 27;
            buttonWinner2.Text = "Win";
            buttonWinner2.UseVisualStyleBackColor = true;
            buttonWinner2.Visible = false;
            buttonWinner2.Click += buttonWinner2_Click;
            // 
            // buttonWinner3
            // 
            buttonWinner3.Location = new Point(458, 136);
            buttonWinner3.Name = "buttonWinner3";
            buttonWinner3.Size = new Size(46, 23);
            buttonWinner3.TabIndex = 28;
            buttonWinner3.Text = "Win";
            buttonWinner3.UseVisualStyleBackColor = true;
            buttonWinner3.Visible = false;
            buttonWinner3.Click += buttonWinner3_Click;
            // 
            // buttonWinner4
            // 
            buttonWinner4.Location = new Point(607, 248);
            buttonWinner4.Name = "buttonWinner4";
            buttonWinner4.Size = new Size(50, 23);
            buttonWinner4.TabIndex = 29;
            buttonWinner4.Text = "Win";
            buttonWinner4.UseVisualStyleBackColor = true;
            buttonWinner4.Visible = false;
            buttonWinner4.Click += buttonWinner4_Click;
            // 
            // labelScore1
            // 
            labelScore1.AutoSize = true;
            labelScore1.Location = new Point(135, 133);
            labelScore1.Name = "labelScore1";
            labelScore1.Size = new Size(35, 15);
            labelScore1.TabIndex = 30;
            labelScore1.Text = "point";
            labelScore1.Visible = false;
            // 
            // labelScore2
            // 
            labelScore2.AutoSize = true;
            labelScore2.Location = new Point(294, 20);
            labelScore2.Name = "labelScore2";
            labelScore2.Size = new Size(35, 15);
            labelScore2.TabIndex = 31;
            labelScore2.Text = "point";
            labelScore2.Visible = false;
            // 
            // labelScore3
            // 
            labelScore3.AutoSize = true;
            labelScore3.Location = new Point(448, 20);
            labelScore3.Name = "labelScore3";
            labelScore3.Size = new Size(35, 15);
            labelScore3.TabIndex = 32;
            labelScore3.Text = "point";
            labelScore3.Visible = false;
            // 
            // labelScore4
            // 
            labelScore4.AutoSize = true;
            labelScore4.Location = new Point(607, 133);
            labelScore4.Name = "labelScore4";
            labelScore4.Size = new Size(35, 15);
            labelScore4.TabIndex = 33;
            labelScore4.Text = "point";
            labelScore4.Visible = false;
            // 
            // labelScoreDealer
            // 
            labelScoreDealer.AutoSize = true;
            labelScoreDealer.Location = new Point(414, 254);
            labelScoreDealer.Name = "labelScoreDealer";
            labelScoreDealer.Size = new Size(35, 15);
            labelScoreDealer.TabIndex = 34;
            labelScoreDealer.Text = "point";
            labelScoreDealer.Visible = false;
            // 
            // buttonPush
            // 
            buttonPush.Location = new Point(380, 418);
            buttonPush.Name = "buttonPush";
            buttonPush.Size = new Size(72, 49);
            buttonPush.TabIndex = 35;
            buttonPush.Text = "Push";
            buttonPush.UseVisualStyleBackColor = true;
            buttonPush.Visible = false;
            buttonPush.Click += buttonPush_Click;
            // 
            // buttonConfirmWinners
            // 
            buttonConfirmWinners.Location = new Point(311, 186);
            buttonConfirmWinners.Name = "buttonConfirmWinners";
            buttonConfirmWinners.Size = new Size(116, 46);
            buttonConfirmWinners.TabIndex = 36;
            buttonConfirmWinners.Text = "Confirm Winners";
            buttonConfirmWinners.UseVisualStyleBackColor = true;
            buttonConfirmWinners.Visible = false;
            buttonConfirmWinners.Click += buttonConfirmWinners_Click;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(635, 20);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(36, 15);
            labelScore.TabIndex = 37;
            labelScore.Text = "Score";
            labelScore.Visible = false;
            // 
            // labelTip
            // 
            labelTip.AutoSize = true;
            labelTip.Location = new Point(623, 58);
            labelTip.Name = "labelTip";
            labelTip.Size = new Size(48, 15);
            labelTip.TabIndex = 38;
            labelTip.Text = "labelTip";
            labelTip.Visible = false;
            // 
            // Page2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelTip);
            Controls.Add(labelScore);
            Controls.Add(buttonConfirmWinners);
            Controls.Add(buttonPush);
            Controls.Add(labelScoreDealer);
            Controls.Add(labelScore4);
            Controls.Add(labelScore3);
            Controls.Add(labelScore2);
            Controls.Add(labelScore1);
            Controls.Add(buttonWinner4);
            Controls.Add(buttonWinner3);
            Controls.Add(buttonWinner2);
            Controls.Add(buttonWinner1);
            Controls.Add(labelPlayer4Bubble);
            Controls.Add(labelPlayer3Bubble);
            Controls.Add(labelPlayer2Bubble);
            Controls.Add(labelPlayer1Bubble);
            Controls.Add(buttonShowDealerCard);
            Controls.Add(buttonDealDealer);
            Controls.Add(buttonDeal4);
            Controls.Add(buttonDeal3);
            Controls.Add(buttonDeal2);
            Controls.Add(buttonDeal1);
            Controls.Add(panelPlayer4Cards);
            Controls.Add(panelPlayer1Cards);
            Controls.Add(panelPlayer3Cards);
            Controls.Add(Deck1Button);
            Controls.Add(Deck2Button);
            Controls.Add(RestartButton);
            Controls.Add(panelDealerCards);
            Controls.Add(panelPlayer2Cards);
            Controls.Add(buttonSet);
            Controls.Add(buttonWinnerDealer);
            Controls.Add(buttonShuffle);
            Controls.Add(pictureBox1);
            Name = "Page2";
            Size = new Size(720, 480);
            Load += Page2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonShuffle;
        private Button buttonWinnerDealer;
        private Button buttonSet;
        private Panel panelPlayer2Cards;
        private Panel panelDealerCards;
        private Button RestartButton;
        private Button Deck2Button;
        private Button Deck1Button;
        private Panel panelPlayer3Cards;
        private Panel panelPlayer1Cards;
        private Panel panelPlayer4Cards;
        private Button buttonDeal1;
        private Button buttonDeal2;
        private Button buttonDeal3;
        private Button buttonDeal4;
        private Button buttonDealDealer;
        private Button buttonShowDealerCard;
        private System.Windows.Forms.Timer timerShuffle;
        private Label labelPlayer1Bubble;
        private Label labelPlayer2Bubble;
        private Label labelPlayer3Bubble;
        private Label labelPlayer4Bubble;
        private Button buttonWinner1;
        private Button buttonWinner2;
        private Button buttonWinner3;
        private Button buttonWinner4;
        private Label labelScore1;
        private Label labelScore2;
        private Label labelScore3;
        private Label labelScore4;
        private Label labelScoreDealer;
        private Button buttonPush;
        private Button buttonConfirmWinners;
        private Label labelScore;
        private Label labelTip;
    }
}
