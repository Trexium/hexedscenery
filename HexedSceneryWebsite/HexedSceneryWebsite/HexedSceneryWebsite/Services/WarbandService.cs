using HexedSceneryData.Data;

namespace HexedSceneryWebsite.Services
{
    public interface IWarbandService
    {
        Task<List<Tuple<int, string>>> GetWarbandValueStore();
    }

    public class WarbandService : IWarbandService
    {
        private readonly HexedSceneryContext _context;

        public WarbandService(HexedSceneryContext context)
        {
            _context = context;
        }

        public async Task<List<Tuple<int, string>>> GetWarbandValueStore()
        {
            var warbands = _context.Warbands.Select(w => new Tuple<int, string>(w.Id, w.Name)).ToList();
            return warbands.OrderBy(w => w.Item2).ToList();
        }
    }
}
