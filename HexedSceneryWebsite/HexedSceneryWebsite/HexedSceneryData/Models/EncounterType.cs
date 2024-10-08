﻿using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class EncounterType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DisplayName { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
}
