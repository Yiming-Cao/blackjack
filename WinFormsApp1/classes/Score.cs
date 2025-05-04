using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.classes
{
    public class Score
    {
        public bool IsFreeHitPhase = false;
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

        public bool JudgePlayerHit(int playerHandValue)
        {
            if (playerHandValue < 17)
            {
                TotalScore += 1;
                return true; // 正确 Hit
            }
            else
            {
                TotalScore -= 1;
                return false; // 错误 Hit
            }
        }

        public bool JudgeDealerDraw(int dealerHandValue, bool allPlayersDone)
        {
            if (allPlayersDone == false)
            {
                // 玩家未完成操作时庄家就发牌，扣分
                TotalScore -= 1;
                return false;
            }

            if (dealerHandValue < 17)
            {
                TotalScore += 1; // 正确 Hit
                return true;
            }
            else
            {
                TotalScore -= 1; // 不应该再发了
                return false;
            }
        }

        public bool JudgeWinnerSelection(List<int> selected, List<int> correct)
        {
            selected.Sort();
            correct.Sort();

            // 排除 -1（代表平局）后比较，或更严格处理
            bool isCorrect = selected.Count == correct.Count && !selected.Except(correct).Any();

            if (isCorrect)
                TotalScore += 1;
            else
                TotalScore -= 1;

            return isCorrect;
        }


    }

}
