using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class MonsterEquipment
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int EquipmentId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Monster Monster { get; set; } = null!;
}
