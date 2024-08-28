using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class HiredSwordCompatibleWarband
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? WarbandId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public Warband? Warband { get; set; }
}
