
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class Monster
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? ProfileId { get; set; }

        public List<Profile>? AdditionalProfiles { get; set; }

        public List<Equipment>? Equipments { get; set; }

        public List<Skill>? Skills { get; set; }

        public List<SpecialRule>? SpecialRules { get; set; }

        public Profile? Profile { get; set; }
    }
}
