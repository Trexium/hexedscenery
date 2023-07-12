using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class ImageImageCategory
{
    public int Id { get; set; }

    public int ImageId { get; set; }

    public int ImageCategory { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual ImageCategory ImageCategoryNavigation { get; set; } = null!;
}
