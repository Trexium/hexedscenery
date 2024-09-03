using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class SpecialRule
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<HiredSwordSpecialRule>? HiredSwordSpecialRules { get; set; }

    public List<MonsterSpecialRule>? MonsterSpecialRules { get; set; }
}
