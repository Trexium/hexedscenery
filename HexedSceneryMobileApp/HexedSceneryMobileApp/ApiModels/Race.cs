using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class Race
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<Warband>? Warbands { get; set; }
}
