namespace HexedSceneryWebsite.Api.v1.Models
{
    public class DiceType
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
    }
}
