using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.classes
{
    public class Dealer : Player
    {
        public bool ShouldHit()
        {
            return Score < 17; // 庄家必须在小于17时继续拿牌
        }
    }
}

