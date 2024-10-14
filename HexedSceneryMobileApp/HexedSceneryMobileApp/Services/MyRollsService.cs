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
        Task AddRoll(Roll roll);
        Task RemoveRoll(Guid id);
        Task RemoveRoll(Roll roll);
        List<Roll> MyRolls { get; }
        Task RemoveAll();
    }
    public class MyRollsService : IMyRollsService
    {
        private readonly IMapper _mapper;
        private readonly IEncounterService _encounterService;
        private readonly IDiceChartService _diceChartService;

        private static Dictionary<Guid, Roll> _rollsCache = new Dictionary<Guid, Roll>();

        public List<Roll> MyRolls => _rollsCache.Values.ToList();

        public MyRollsService(IMapper mapper, IEncounterService encounterService, IDiceChartService diceChartService)
        {
            _mapper = mapper;
            _encounterService = encounterService;
            _diceChartService = diceChartService;
        }

        public async Task AddRoll(Encounter encounter)
        {
            var roll = _mapper.Map<Roll>(encounter);
            roll.TableName = (await _encounterService.GetEncounterTypeAsync(encounter.EncounterTypeId)).DisplayName;
            _rollsCache.Add(roll.Id, roll);
        }

        public async Task AddRoll(DiceResult diceResult)
        {
            var roll = _mapper.Map<Roll>(diceResult);
            roll.TableName = (await _diceChartService.GetDiceChartAsync(diceResult.DiceChartId)).Name;
            _rollsCache.Add(roll.Id, roll);
        }

        public async Task AddRoll(Roll roll)
        {
            roll = _mapper.Map<Roll>(roll);

            if (roll)
            roll.TableName = (await _encounterService.GetEncounterTypeAsync(roll.Encounter.EncounterTypeId)).DisplayName;

            if (roll.)

            _rollsCache.Add(roll.Id, roll);
        }


        // Not complete, probobly has to be rewritten
        public async Task AddChildRoll(Encounter parent, DiceResult child)
        {
            var parentTableName = (await _encounterService.GetEncounterTypeAsync(parent.EncounterTypeId)).DisplayName;
            
            var parentId = _rollsCache.Values.FirstOrDefault(m => m.TableName == parentTableName && !m.ChildChartResult.HasValue)?.Id;

            if (parentId.HasValue)
            {
                var childChart = await _diceChartService.GetDiceChartAsync(child.DiceChartId);
            }
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

        public async Task RemoveAll()
        {
            _rollsCache.Clear();
        }
    }
}
