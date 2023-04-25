using System;
using System.Collections.Generic;
using System.Text;

namespace HexedSceneryCommon.Mordheim
{
    public class HiredSword
    {
        public HiredSword() 
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HireFee { get; set; }
        public string HireFeeDescription { get; set; }
        public int UpkeepCost { get; set; }
        public string UpkeepCostDescription { get; set; }
        public List<Warband> CompatibleWarbands { get; set; }
        public string CompatabilityDescription { get; set; }
        public Profile Profile { get; set; }
        public List<Profile> AdditionalProfiles { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<SpecialRule> SpecialRules { get; set; }
        public List<Skill> Skills { get; set; }
        public Grade Grade { get; set; }
        public Source Source { get; set; }


    }
}
