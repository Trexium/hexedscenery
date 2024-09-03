namespace HexedSceneryWebsite.Api.v1.Models
{
    public class TableCategory
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public bool? Active { get; set; }
        public IEnumerable<EncounterType>? EncounterTypes { get; set; }
    }
}
