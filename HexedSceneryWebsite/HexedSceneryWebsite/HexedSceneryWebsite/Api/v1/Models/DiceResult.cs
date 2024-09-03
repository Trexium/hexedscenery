namespace HexedSceneryWebsite.Api.v1.Models
{
    public class DiceResult
    {
        public int Id { get; set; }
        public int ResultNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DiceChartId { get; set; }
    }
}
