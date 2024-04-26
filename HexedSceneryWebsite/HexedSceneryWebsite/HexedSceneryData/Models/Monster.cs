using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Monster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProfileId { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<MonsterAdditionalProfile> MonsterAdditionalProfiles { get; set; } = new List<MonsterAdditionalProfile>();

    public virtual ICollection<MonsterEquipment> MonsterEquipments { get; set; } = new List<MonsterEquipment>();

    public virtual ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();

    public virtual ICollection<MonsterSpecialRule> MonsterSpecialRules { get; set; } = new List<MonsterSpecialRule>();

    public virtual Profile? Profile { get; set; }
}
