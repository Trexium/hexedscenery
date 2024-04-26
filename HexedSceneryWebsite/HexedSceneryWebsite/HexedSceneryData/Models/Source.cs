using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Source
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string? PdfUrl { get; set; }

    public virtual ICollection<HiredSword> HiredSwords { get; set; } = new List<HiredSword>();
}
