using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class Source
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Key { get; set; }

    public string? PdfUrl { get; set; }

    public List<HiredSword>? HiredSwords { get; set; }
}
