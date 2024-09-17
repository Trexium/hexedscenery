using AutoMapper;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IMyRollsService
    {
        Task<List<Roll>> GetMyRolls();
        Task AddRoll(Encounter encounter);
        Task AddRoll(DiceResult diceResult);
        Task RemoveRoll(Guid id);
        Task RemoveRoll(Roll roll);
    }
    public class MyRollsService : IMyRollsService
    {
        private readonly IMapper _mapper;

        private static Dictionary<Guid, Roll> _rollsCache = new Dictionary<Guid, Roll>();

        public MyRollsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddRoll(Encounter encounter)
        {
            var roll = _mapper.Map<Roll>(encounter);
            _rollsCache.Add(roll.Id, roll);
        }

        public async Task AddRoll(DiceResult diceResult)
        {
            var roll = _mapper.Map<Roll>(diceResult);
            _rollsCache.Add(roll.Id, roll);
        }

        public async Task<List<Roll>> GetMyRolls()
        {
            return _rollsCache.Values.ToList();
        }

        public async Task RemoveRoll(Guid id)
        {
            if (_rollsCache.ContainsKey(id))
            {
                _rollsCache.Remove(id);
            }
        }

        public async Task RemoveRoll(Roll roll)
        {
            await RemoveRoll(roll.Id);
        }
    }
}
