namespace WinFormsApp1
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
            buttonDeal = new Button();
            buttonShow = new Button();
            panelPlayer2Cards = new Panel();
            panelDealerCards = new Panel();
            button6 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
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
            // buttonDeal
            // 
            buttonDeal.Location = new Point(150, 418);
            buttonDeal.Name = "buttonDeal";
            buttonDeal.Size = new Size(92, 49);
            buttonDeal.TabIndex = 7;
            buttonDeal.Text = "Deal";
            buttonDeal.UseVisualStyleBackColor = true;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(495, 418);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(92, 49);
            buttonShow.TabIndex = 8;
            buttonShow.Text = "Show";
            buttonShow.UseVisualStyleBackColor = true;
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
            // button6
            // 
            button6.Location = new Point(607, 418);
            button6.Name = "button6";
            button6.Size = new Size(92, 49);
            button6.TabIndex = 10;
            button6.Text = "Restart";
            button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(592, 353);
            button3.Name = "button3";
            button3.Size = new Size(92, 34);
            button3.TabIndex = 11;
            button3.Text = "2 deck";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(592, 312);
            button4.Name = "button4";
            button4.Size = new Size(92, 35);
            button4.TabIndex = 12;
            button4.Text = "1 deck";
            button4.UseVisualStyleBackColor = true;
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
            buttonDeal1.Location = new Point(88, 248);
            buttonDeal1.Name = "buttonDeal1";
            buttonDeal1.Size = new Size(75, 23);
            buttonDeal1.TabIndex = 16;
            buttonDeal1.Text = "Deal1";
            buttonDeal1.UseVisualStyleBackColor = true;
            buttonDeal1.Click += buttonDeal1_Click;
            // 
            // buttonDeal2
            // 
            buttonDeal2.Location = new Point(233, 136);
            buttonDeal2.Name = "buttonDeal2";
            buttonDeal2.Size = new Size(75, 23);
            buttonDeal2.TabIndex = 17;
            buttonDeal2.Text = "Deal2";
            buttonDeal2.UseVisualStyleBackColor = true;
            buttonDeal2.Click += buttonDeal2_Click;
            // 
            // buttonDeal3
            // 
            buttonDeal3.Location = new Point(410, 136);
            buttonDeal3.Name = "buttonDeal3";
            buttonDeal3.Size = new Size(75, 23);
            buttonDeal3.TabIndex = 18;
            buttonDeal3.Text = "Deal3";
            buttonDeal3.UseVisualStyleBackColor = true;
            buttonDeal3.Click += buttonDeal3_Click;
            // 
            // buttonDeal4
            // 
            buttonDeal4.Location = new Point(546, 248);
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
            buttonShowDealerCard.Location = new Point(311, 418);
            buttonShowDealerCard.Name = "buttonShowDealerCard";
            buttonShowDealerCard.Size = new Size(103, 49);
            buttonShowDealerCard.TabIndex = 21;
            buttonShowDealerCard.Text = "SeeDealerCard";
            buttonShowDealerCard.UseVisualStyleBackColor = true;
            buttonShowDealerCard.Click += buttonShowDealerCard_Click;
            // 
            // labelPlayer1Bubble
            // 
            labelPlayer1Bubble.AutoSize = true;
            labelPlayer1Bubble.Location = new Point(101, 124);
            labelPlayer1Bubble.Name = "labelPlayer1Bubble";
            labelPlayer1Bubble.Size = new Size(38, 15);
            labelPlayer1Bubble.TabIndex = 22;
            labelPlayer1Bubble.Text = "label1";
            labelPlayer1Bubble.Visible = false;
            // 
            // labelPlayer2Bubble
            // 
            labelPlayer2Bubble.AutoSize = true;
            labelPlayer2Bubble.Location = new Point(270, 20);
            labelPlayer2Bubble.Name = "labelPlayer2Bubble";
            labelPlayer2Bubble.Size = new Size(38, 15);
            labelPlayer2Bubble.TabIndex = 23;
            labelPlayer2Bubble.Text = "label2";
            labelPlayer2Bubble.Visible = false;
            // 
            // labelPlayer3Bubble
            // 
            labelPlayer3Bubble.AutoSize = true;
            labelPlayer3Bubble.Location = new Point(410, 20);
            labelPlayer3Bubble.Name = "labelPlayer3Bubble";
            labelPlayer3Bubble.Size = new Size(38, 15);
            labelPlayer3Bubble.TabIndex = 24;
            labelPlayer3Bubble.Text = "label3";
            labelPlayer3Bubble.Visible = false;
            // 
            // labelPlayer4Bubble
            // 
            labelPlayer4Bubble.AutoSize = true;
            labelPlayer4Bubble.Location = new Point(583, 133);
            labelPlayer4Bubble.Name = "labelPlayer4Bubble";
            labelPlayer4Bubble.Size = new Size(38, 15);
            labelPlayer4Bubble.TabIndex = 25;
            labelPlayer4Bubble.Text = "label4";
            labelPlayer4Bubble.Visible = false;
            // 
            // Page2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(panelDealerCards);
            Controls.Add(panelPlayer2Cards);
            Controls.Add(buttonShow);
            Controls.Add(buttonDeal);
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
        private Button buttonDeal;
        private Button buttonShow;
        private Panel panelPlayer2Cards;
        private Panel panelDealerCards;
        private Button button6;
        private Button button3;
        private Button button4;
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
    }
}
