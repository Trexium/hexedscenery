using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class MonsterAdditionalProfile
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int ProfileId { get; set; }

    public virtual Monster Monster { get; set; } = null!;

    public virtual Profile Profile { get; set; } = null!;
}
