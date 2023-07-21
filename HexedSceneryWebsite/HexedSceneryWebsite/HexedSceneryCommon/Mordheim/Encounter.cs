using System;
using System.Collections.Generic;
using System.Text;

namespace HexedSceneryCommon.Mordheim
{
    public class Encounter
    {
        public int ResultNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BottomText { get; set; }
        public DiceChart DiceChart { get; set; }
        public Monster Monster { get; set; }
        public int EncounterTypeId { get; set; }
    }
}
