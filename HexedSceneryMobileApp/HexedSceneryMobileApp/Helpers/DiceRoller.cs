using HexedSceneryApiClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Helpers
{
    public interface IDiceRoller
    {
        Task<int> Roll(int diceTypeId, int numberOfDice = 1);
    }
    public class DiceRoller : IDiceRoller
    {
        private readonly IDiceService _diceService;

        public DiceRoller(IDiceService diceService)
        {
            _diceService = diceService;
        }
        public async Task<int> Roll(int diceTypeId, int numberOfDice = 1)
        {
            var diceType = await _diceService.GetDiceTypeAsync(diceTypeId);


        }
    }
}
