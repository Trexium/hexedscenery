using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class ImageCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ImageImageCategory> ImageImageCategories { get; set; } = new List<ImageImageCategory>();
}
