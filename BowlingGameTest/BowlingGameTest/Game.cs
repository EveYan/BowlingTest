using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameTest
{
    class Game
    {
        private int nscore = 0;
        private int[] rolls = new int[21];
        private int currentOne = 0;

        public void roll(int pins)
        {
            rolls[currentOne++] = pins;
        }

        public int score()
        {
            nscore = 0;
            for (int loop = 0; loop < currentOne; ++loop)
            {
                nscore += rolls[loop];
                if (isStrike(loop))
                {
                    nscore += rolls[loop + 1];
                    nscore += rolls[loop + 2];
                }
                else if (isSpare(loop))
                {
                    nscore += rolls[loop + 1];
                    nscore += rolls[loop + 2];
                    loop += 1;
                }

            }
            return nscore;
        }

        private bool isStrike(int loop)
        {
            return (rolls[loop] == 10 && loop < currentOne - 3);
        }

        private Boolean isSpare(int loop)
        {
            return (loop <= currentOne - 1 && rolls[loop] + rolls[loop + 1] == 10);
           
        }
    }
}
