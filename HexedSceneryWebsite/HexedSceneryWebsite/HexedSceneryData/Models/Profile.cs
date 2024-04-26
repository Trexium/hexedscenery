using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Movement { get; set; } = null!;

    public string WeaponSkill { get; set; } = null!;

    public string BallisticSkill { get; set; } = null!;

    public string Strength { get; set; } = null!;

    public string Toughness { get; set; } = null!;

    public string Wounds { get; set; } = null!;

    public string Initiative { get; set; } = null!;

    public string Attacks { get; set; } = null!;

    public string Leadership { get; set; } = null!;

    public virtual ICollection<HiredSwordAdditionalProfile> HiredSwordAdditionalProfiles { get; set; } = new List<HiredSwordAdditionalProfile>();

    public virtual ICollection<HiredSword> HiredSwords { get; set; } = new List<HiredSword>();

    public virtual ICollection<MonsterAdditionalProfile> MonsterAdditionalProfiles { get; set; } = new List<MonsterAdditionalProfile>();

    public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
}
