﻿namespace HexedSceneryWebsite.Api.v1.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<HiredSword>? HiredSwords { get; set; }
    }
}