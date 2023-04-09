using System;
using System.Collections.Generic;
using System.Text;

namespace HexedSceneryCommon.Mordheim
{
    public class DiceChart
    {
        public string Dice { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }

        public List<DiceResult> DiceResults { get; set; }
    }
}
