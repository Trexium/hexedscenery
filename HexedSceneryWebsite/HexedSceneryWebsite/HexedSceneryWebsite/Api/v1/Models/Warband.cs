
namespace HexedSceneryWebsite.Api.v1.Models
{
    public class Warband
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RaceId { get; set; }
        public Race? Race { get; set; }
        public IEnumerable<int> CompatibleHiredSwordIds { get; set; }
    }
}
