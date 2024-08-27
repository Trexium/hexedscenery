using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class Monster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ProfileId { get; set; }

    public List<Encounter>? Encounters { get; set; }

    public List<MonsterAdditionalProfile>? MonsterAdditionalProfiles { get; set; }

    public List<MonsterEquipment>? MonsterEquipments { get; set; }

    public List<MonsterSkill>? MonsterSkills { get; set; }

    public List<MonsterSpecialRule>? MonsterSpecialRules { get; set; }

    public Profile? Profile { get; set; }
}
