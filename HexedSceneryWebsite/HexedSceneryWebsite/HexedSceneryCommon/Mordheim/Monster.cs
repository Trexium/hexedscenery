using System;
using System.Collections.Generic;
using System.Text;

namespace HexedSceneryCommon.Mordheim
{
    public class Monster
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Profile Profile { get; set; }
        public List<Profile> AdditionalProfiles { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SpecialRule> SpecialRules { get; set; }
        public List<Equipment> Equipment { get; set; }
    }
}
