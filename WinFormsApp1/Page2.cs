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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Page2 : UserControl
    {
        private Game game;
        private System.Windows.Forms.Timer shuffleTimer;
        private int shuffleFrame = 0;
        private PictureBox shuffleBox;
        private System.Windows.Forms.Timer decisionTimer;
        private List<int> selectedWinners = new List<int>();




        public Page2()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Page2_Load(object sender, EventArgs e)
        {
            decisionTimer = new System.Windows.Forms.Timer();
            decisionTimer.Interval = 1000;
            decisionTimer.Tick += DecisionTimer_Tick;

        }

        private void StartShuffleAnimation()
        {
             
            if (shuffleBox != null && this.Controls.Contains(shuffleBox))
                this.Controls.Remove(shuffleBox);

            
            shuffleBox = new PictureBox
            {
                Size = new Size(80, 120),
                Location = new Point(Width / 2 - 40, Height / 2 - 60),  
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            
            using (MemoryStream ms = new MemoryStream(Properties.Resources.back_of_card))
            {
                shuffleBox.Image = Image.FromStream(ms);
            }

            this.Controls.Add(shuffleBox);
            shuffleBox.BringToFront();

             
            shuffleFrame = 0;
            shuffleTimer = new System.Windows.Forms.Timer();
            shuffleTimer.Interval = 50;   
            shuffleTimer.Tick += ShuffleTimer_Tick;
            shuffleTimer.Start();
        }

        private void ShuffleTimer_Tick(object sender, EventArgs e)
        {
            shuffleFrame++;

            
            shuffleBox.Left = this.Width / 2 - 40 + (shuffleFrame % 2 == 0 ? -5 : 5);
            shuffleBox.Top = this.Height / 2 - 60 + (shuffleFrame % 3 - 1) * 3;

            if (shuffleFrame > 20) 
            {
                shuffleTimer.Stop();
                shuffleTimer.Dispose();
                this.Controls.Remove(shuffleBox); 
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
                decisionTimer.Start(); 
            }

            ShowAllScores();

        }

        private void DealAndScorePlayer(int playerIndex, Panel playerPanel)
        {
            if (!game.ScoreSystem.IsFreeHitPhase)
            {
                
                DealToPlayer(playerIndex, playerPanel);
                bool isCorrect = game.ScoreSystem.ValidateStep($"Deal_Player{playerIndex + 1}");
                UpdateScoreDisplay(isCorrect);
            }
            else
            {
                
                int handValue = game.GetPlayer(playerIndex).GetHandValue();
                Card card = game.DealCardToPlayer(playerIndex, true);  
                if (card != null)
                {
                    ShowCardInPanel(card, playerPanel, game.GetPlayer(playerIndex).Hand.Count - 1);
                }
                bool hitCorrectly = game.ScoreSystem.JudgePlayerHit(handValue);
                UpdateScoreDisplay(hitCorrectly);
                ShowAllScores();

                
                int newHandValue = game.GetPlayer(playerIndex).GetHandValue();
                if (newHandValue > 21)
                {
                    game.GetPlayer(playerIndex).IsDone = true;
                    ShowPlayerDecision(playerIndex, "Bust"); 
                }
                else if (newHandValue >= 17)
                {
                    game.GetPlayer(playerIndex).IsDone = true;
                    ShowPlayerDecision(playerIndex, "Stand");
                }
                else
                {
                    ShowPlayerDecision(playerIndex, "Hit");
                }

                RefreshPlayerDecisions();  

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
            
            using (MemoryStream ms = new MemoryStream(Properties.Resources.back_of_card))
            {
                pb.Image = Image.FromStream(ms);
            }
            pb.Tag = card;  
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
                    secondCard.Image = realCard.Img;  
                }
            }
        }

        private void buttonDeal1_Click(object sender, EventArgs e)
        {
            DealAndScorePlayer(0, panelPlayer1Cards);
        }

        private void buttonDeal2_Click(object sender, EventArgs e)
        {
            DealAndScorePlayer(1, panelPlayer2Cards);
        }

        private void buttonDeal3_Click(object sender, EventArgs e)
        {
            DealAndScorePlayer(2, panelPlayer3Cards);
        }

        private void buttonDeal4_Click(object sender, EventArgs e)
        {
            DealAndScorePlayer(3, panelPlayer4Cards);
        }

        private void buttonDealDealer_Click(object sender, EventArgs e)
        {
            int dealerCount = game.DealerCardCount();
            if (dealerCount == 0)
            {
                
                Card c = game.DealDealerFirstCard();
                if (c != null)
                    ShowCardInPanel(c, panelDealerCards, 0);
                ShowAllScores();

                bool isCorrect = game.ScoreSystem.ValidateStep("Deal_Dealer_First");
                UpdateScoreDisplay(isCorrect);
            }
            else if (dealerCount == 1)
            {
                
                Card c = game.DealDealerSecondCard();
                if (c != null)
                    ShowHiddenCardInPanel(c, panelDealerCards, 1);

                
                if (AllPlayersAndDealerHaveTwoCards())
                {
                    decisionTimer.Start(); 
                }
                ShowAllScores();

                bool isCorrect = game.ScoreSystem.ValidateStep("Deal_Dealer_Second");
                UpdateScoreDisplay(isCorrect);
                game.ScoreSystem.IsFreeHitPhase = true;

            }
            else
            {
                
                int dealerHandValue = game.GetDealer().GetHandValue();
                bool allPlayersDone = game.AreAllPlayersDone();

                if (allPlayersDone)
                {
                    Card c = game.DealExtraDealerCard(); 
                    if (c != null)
                    {
                        ShowCardInPanel(c, panelDealerCards, dealerCount);
                    }

                    
                    bool isCorrect = game.ScoreSystem.JudgeDealerDraw(dealerHandValue, allPlayersDone);
                    UpdateScoreDisplay(isCorrect);
                    ShowAllScores();
                }
                else
                {
                    
                    bool isCorrect = game.ScoreSystem.JudgeDealerDraw(dealerHandValue, false);
                    UpdateScoreDisplay(isCorrect);
                }
            }
        }

        private void buttonShowDealerCard_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelDealerCards.Controls)
            {
                if (ctrl is PictureBox pb && pb.Tag is Card card)
                {
                    
                    MessageBox.Show($"Hidden card is：{card}");
                    return;
                }
            }

            MessageBox.Show("No Hidden Card !!");
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            StartShuffleAnimation(); 
            game.ShuffleDeck();      

            bool isCorrect = game.ScoreSystem.ValidateStep("Shuffle");
            UpdateScoreDisplay(isCorrect);
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
            decisionTimer.Stop(); 
            RefreshPlayerDecisions();

        }

        private void Deck1Button_Click(object sender, EventArgs e)
        {
            
            game.SetDeckCount(1);
            MessageBox.Show("Using 1 deck !");

            bool isCorrect = game.ScoreSystem.ValidateStep("ChooseDeckCount");
            UpdateScoreDisplay(isCorrect);
        }

        private void Deck2Button_Click(object sender, EventArgs e)
        {
            
            game.SetDeckCount(2);
            MessageBox.Show("Using 2 deck !");

            bool isCorrect = game.ScoreSystem.ValidateStep("ChooseDeckCount");
            UpdateScoreDisplay(isCorrect);
        }

        private void ShowAllScores()
        {
            labelScore1.Text = $"{game.GetPlayer(0).GetHandValue()}";
            labelScore2.Text = $"{game.GetPlayer(1).GetHandValue()}";
            labelScore3.Text = $"{game.GetPlayer(2).GetHandValue()}";
            labelScore4.Text = $"{game.GetPlayer(3).GetHandValue()}";
            labelScoreDealer.Text = $"{game.GetDealer().GetHandValue()}";

            labelScore1.Visible = true;
            labelScore2.Visible = true;
            labelScore3.Visible = true;
            labelScore4.Visible = true;
            labelScoreDealer.Visible = true;
        }


        private void buttonSet_Click(object sender, EventArgs e)
        {
            ShowWinnerButtons();  
        }

        private void ShowWinnerButtons()
        {
            buttonWinner1.Visible = true;
            buttonWinner2.Visible = true;
            buttonWinner3.Visible = true;
            buttonWinner4.Visible = true;
            buttonWinnerDealer.Visible = true;
            buttonPush.Visible = true;
            buttonConfirmWinners.Visible = true;
        }

        private void buttonWinner1_Click(object sender, EventArgs e)
        {
            ToggleWinner(0, buttonWinner1);
        }

        private void buttonWinner2_Click(object sender, EventArgs e)
        {
            ToggleWinner(1, buttonWinner2);
        }

        private void buttonWinner3_Click(object sender, EventArgs e)
        {
            ToggleWinner(2, buttonWinner3);
        }

        private void buttonWinner4_Click(object sender, EventArgs e)
        {
            ToggleWinner(3, buttonWinner4);
        }

        private void buttonWinnerDealer_Click(object sender, EventArgs e)
        {
            ToggleWinner(4, buttonWinnerDealer);
        }

        private void buttonPush_Click(object sender, EventArgs e)
        {
            ToggleWinner(-1, buttonPush);
        }

        private void ToggleWinner(int index, Button button)
        {
            if (selectedWinners.Contains(index))
            {
                selectedWinners.Remove(index);
                button.BackColor = SystemColors.Control;  
            }
            else
            {
                selectedWinners.Add(index);
                button.BackColor = Color.LightGreen;  
            }
        }

        private void buttonConfirmWinners_Click(object sender, EventArgs e)
        {
            if (selectedWinners.Count == 0)
            {
                MessageBox.Show("Choose at least one winner!");
                return;
            }

            if (selectedWinners.Contains(-1))
            {
                MessageBox.Show("Push（No winner）!", "Result");
                var correctWinners = game.GetRecommendedWinners();
                bool isCorrect = game.ScoreSystem.JudgeWinnerSelection(selectedWinners, correctWinners);

                MessageBox.Show(isCorrect ? "✔！+1 " : "✘！-1 ", "Result");
                UpdateScoreDisplay(isCorrect);

                if (isCorrect)
                {
                    selectedWinners.Clear();
                    ResetWinnerButtons();
                    buttonSet.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Wrong Choice！");
                }
                return;
            }
            else
            {
                game.SetMultipleWinners(selectedWinners);
                string winnerNames = game.GetMultipleWinnerNames();

                var correctWinners = game.GetRecommendedWinners();
                bool isCorrect = game.ScoreSystem.JudgeWinnerSelection(selectedWinners, correctWinners);

                MessageBox.Show($"{winnerNames} Win!\n" + (isCorrect ? "✔！+1 " : "✘！-1 "), "Result");
                UpdateScoreDisplay(isCorrect);

                if (isCorrect)
                {
                    
                    selectedWinners.Clear();
                    ResetWinnerButtons();
                    buttonSet.Enabled = false;
                }
                else
                {
                    
                    MessageBox.Show("Wrong Choice！");
                }
            }

        }

        private void ResetWinnerButtons()
        {
            buttonWinner1.BackColor = SystemColors.Control;
            buttonWinner2.BackColor = SystemColors.Control;
            buttonWinner3.BackColor = SystemColors.Control;
            buttonWinner4.BackColor = SystemColors.Control;
            buttonWinnerDealer.BackColor = SystemColors.Control;
            buttonPush.BackColor = SystemColors.Control;

            buttonWinner1.Visible = false;
            buttonWinner2.Visible = false;
            buttonWinner3.Visible = false;
            buttonWinner4.Visible = false;
            buttonWinnerDealer.Visible = false;
            buttonPush.Visible = false;
            buttonConfirmWinners.Visible = false;
        }


        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Clear all player card images  
            foreach (var panel in new[] { panelPlayer1Cards, panelPlayer2Cards, panelPlayer3Cards, panelPlayer4Cards, panelDealerCards })
            {
                // Iterate through each control in the panel  
                for (int i = panel.Controls.Count - 1; i >= 0; i--) // Remove from back to front  
                {
                    Control ctrl = panel.Controls[i];
                    if (ctrl is PictureBox pb)
                    {
                        pb.Dispose();  // Remove image  
                    }
                }
            }

            // Clear all player bubble text  
            foreach (var label in new[] { labelPlayer1Bubble, labelPlayer2Bubble, labelPlayer3Bubble, labelPlayer4Bubble })
            {
                label.Text = string.Empty;
                label.Visible = false;  // Hide bubble  
            }
            buttonSet.Enabled = true;
            labelScore1.Text = "";
            labelScore2.Text = "";
            labelScore3.Text = "";
            labelScore4.Text = "";
            labelScoreDealer.Text = "";

            labelScore1.Visible = false;
            labelScore2.Visible = false;
            labelScore3.Visible = false;
            labelScore4.Visible = false;
            labelScoreDealer.Visible = false;
            game.RestartGame();
            game.ScoreSystem.Reset();              
            game.ScoreSystem.IsFreeHitPhase = false;
            UpdateScoreDisplay(true);              
            MessageBox.Show("Game restart !");
        }

        private void UpdateScoreDisplay(bool isCorrect)
        {
            labelScore.Text = "Score: " + game.ScoreSystem.TotalScore;

            if (isCorrect)
                labelTip.Text = "✔right step +1 ";
            else
                labelTip.Text = "✘wrong step -1 ";

            labelTip.Visible = true;  
            labelScore.Visible = true;
        }

        private void RefreshPlayerDecisions()
        {
            for (int i = 0; i < 4; i++)
            {
                if (game.GetPlayer(i).IsDone)
                    continue;

                int total = game.GetPlayer(i).GetHandValue();
                if (total > 21)
                {
                    ShowPlayerDecision(i, "Bust");
                    game.GetPlayer(i).IsDone = true;
                }
                else if (total >= 17)
                {
                    ShowPlayerDecision(i, "Stand");
                    game.GetPlayer(i).IsDone = true;
                }
                else
                {
                    ShowPlayerDecision(i, "Hit");
                }
            }
        }




    }
}
