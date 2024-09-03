using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class Grade
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<HiredSword>? HiredSwords { get; set; }
}
