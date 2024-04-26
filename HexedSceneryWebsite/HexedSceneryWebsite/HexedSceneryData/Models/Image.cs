using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Image
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Priority { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<ImageImageCategory> ImageImageCategories { get; set; } = new List<ImageImageCategory>();
}
