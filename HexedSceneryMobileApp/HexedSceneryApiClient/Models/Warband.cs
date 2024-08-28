using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class Warband
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RaceId { get; set; }

    public List<HiredSwordCompatibleWarband>? HiredSwordCompatibleWarbands { get; set; }

    public Race? Race { get; set; }
}
