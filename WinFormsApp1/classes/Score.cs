using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.classes
{
    public class Score
    {
        private List<string> correctSteps = new List<string>
    {
        "ChooseDeckCount",
        "Shuffle",
        "Deal_Player1",
        "Deal_Player2",
        "Deal_Player3",
        "Deal_Player4",
        "Deal_Dealer_First",
        "Deal_Player1",
        "Deal_Player2",
        "Deal_Player3",
        "Deal_Player4",
        "Deal_Dealer_Second"
    };

        private int currentStepIndex = 0;
        public int TotalScore { get; private set; } = 0;

        public string GetExpectedStep()
        {
            if (currentStepIndex >= correctSteps.Count)
                return null;
            return correctSteps[currentStepIndex];
        }

        public bool ValidateStep(string step)
        {
            if (step == GetExpectedStep())
            {
                TotalScore += 1;
                currentStepIndex++;
                return true;
            }
            else
            {
                TotalScore -= 1;
                return false;
            }
        }

        public void Reset()
        {
            currentStepIndex = 0;
            TotalScore = 0;
        }
    }

}
