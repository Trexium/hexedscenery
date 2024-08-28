using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class HiredSword
{
    public int Id { get; set; }

    public string? Name { get; set; }

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

    public Grade? Grade { get; set; }

    public List<HiredSwordAdditionalProfile>? HiredSwordAdditionalProfiles { get; set; }

    public List<HiredSwordCompatibleWarband>? HiredSwordCompatibleWarbands { get; set; }

    public List<HiredSwordEquipment>? HiredSwordEquipments { get; set; }

    public List<HiredSwordSkillType>? HiredSwordSkillTypes { get; set; }

    public List<HiredSwordSkill>? HiredSwordSkills { get; set; }

    public List<HiredSwordSpecialRule>? HiredSwordSpecialRules { get; set; }

    public Profile? Profile { get; set; }

    public Source? Source { get; set; }
}
