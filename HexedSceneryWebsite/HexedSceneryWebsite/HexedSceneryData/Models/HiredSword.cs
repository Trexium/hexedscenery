using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSword
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int HireFee { get; set; }

    public string? HireFeeDescription { get; set; }

    public int UpkeepCost { get; set; }

    public string? UpkeepCostDescription { get; set; }

    public string? CompatabilityDescription { get; set; }

    public int ProfileId { get; set; }

    public int GradeId { get; set; }

    public int SourceId { get; set; }

    public string? Rating { get; set; }

    public bool Active { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<HiredSwordAdditionalProfile> HiredSwordAdditionalProfiles { get; set; } = new List<HiredSwordAdditionalProfile>();

    public virtual ICollection<HiredSwordCompatibleWarband> HiredSwordCompatibleWarbands { get; set; } = new List<HiredSwordCompatibleWarband>();

    public virtual ICollection<HiredSwordEquipment> HiredSwordEquipments { get; set; } = new List<HiredSwordEquipment>();

    public virtual ICollection<HiredSwordSkillType> HiredSwordSkillTypes { get; set; } = new List<HiredSwordSkillType>();

    public virtual ICollection<HiredSwordSkill> HiredSwordSkills { get; set; } = new List<HiredSwordSkill>();

    public virtual ICollection<HiredSwordSpecialRule> HiredSwordSpecialRules { get; set; } = new List<HiredSwordSpecialRule>();

    public virtual Profile Profile { get; set; } = null!;

    public virtual Source Source { get; set; } = null!;
}
