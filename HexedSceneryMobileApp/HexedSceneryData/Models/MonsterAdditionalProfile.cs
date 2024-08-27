using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class MonsterAdditionalProfile
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int ProfileId { get; set; }

    public Monster Monster { get; set; } = null!;

    public Profile Profile { get; set; } = null!;
}
