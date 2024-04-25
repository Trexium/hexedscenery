using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class MonsterEquipment
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public string? Equipment { get; set; }

    public virtual Monster Monster { get; set; } = null!;
}
