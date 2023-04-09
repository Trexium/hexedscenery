using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Monster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProfileId { get; set; }

    public virtual ICollection<Encounter> Encounters { get; } = new List<Encounter>();

    public virtual ICollection<MonsterAdditionalProfile> MonsterAdditionalProfiles { get; } = new List<MonsterAdditionalProfile>();

    public virtual ICollection<MonsterSkill> MonsterSkills { get; } = new List<MonsterSkill>();

    public virtual ICollection<MonsterSpecialRule> MonsterSpecialRules { get; } = new List<MonsterSpecialRule>();

    public virtual Profile? Profile { get; set; }
}
