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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page2));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panelPlayerCards = new Panel();
            panelDealerCards = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(714, 402);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(314, 209);
            button1.Name = "button1";
            button1.Size = new Size(98, 57);
            button1.TabIndex = 1;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(29, 418);
            button2.Name = "button2";
            button2.Size = new Size(92, 49);
            button2.TabIndex = 5;
            button2.Text = "Stand";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(148, 418);
            button3.Name = "button3";
            button3.Size = new Size(92, 49);
            button3.TabIndex = 6;
            button3.Text = "Bet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(268, 418);
            button4.Name = "button4";
            button4.Size = new Size(92, 49);
            button4.TabIndex = 7;
            button4.Text = "Hit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(384, 418);
            button5.Name = "button5";
            button5.Size = new Size(92, 49);
            button5.TabIndex = 8;
            button5.Text = "Fold";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // panelPlayerCards
            // 
            panelPlayerCards.BackColor = Color.Transparent;
            panelPlayerCards.BackgroundImage = (Image)resources.GetObject("panelPlayerCards.BackgroundImage");
            panelPlayerCards.BackgroundImageLayout = ImageLayout.Center;
            panelPlayerCards.Location = new Point(276, 272);
            panelPlayerCards.Name = "panelPlayerCards";
            panelPlayerCards.RightToLeft = RightToLeft.No;
            panelPlayerCards.Size = new Size(200, 100);
            panelPlayerCards.TabIndex = 9;
            // 
            // panelDealerCards
            // 
            panelDealerCards.BackColor = Color.Transparent;
            panelDealerCards.BackgroundImage = (Image)resources.GetObject("panelDealerCards.BackgroundImage");
            panelDealerCards.Location = new Point(276, 32);
            panelDealerCards.Name = "panelDealerCards";
            panelDealerCards.Size = new Size(200, 100);
            panelDealerCards.TabIndex = 0;
            // 
            // Page2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelDealerCards);
            Controls.Add(panelPlayerCards);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Page2";
            Size = new Size(720, 480);
            Load += Page2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel panelPlayerCards;
        private Panel panelDealerCards;
    }
}
