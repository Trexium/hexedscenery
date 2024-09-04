
using HexedSceneryMobileApp.Enums;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Helpers
{
    public interface IDiceRollHelper
    {
        Task<int> Roll(DiceType diceType, int numberOfDice = 1);
        Task<int> RollD2(int numberOfDice = 1);
        Task<int> RollD3(int numberOfDice = 1);
        Task<int> RollD4(int numberOfDice = 1);
        Task<int> RollD6(int numberOfDice = 1);
        Task<int> RollD8(int numberOfDice = 1);
        Task<int> RollD10(int numberOfDice = 1);
        Task<int> RollD12(int numberOfDice = 1);
        Task<int> RollD20(int numberOfDice = 1);
        Task<int> RollD66();
        Task<int> RollD100(int numberOfDice = 1);
    }
    public class DiceRollHelper : IDiceRollHelper
    {

        public async Task<int> Roll(DiceType diceType, int numberOfDice = 1)
        {
            return await DoRollLogic(diceType, numberOfDice);
        }

        public async Task<int> RollD2(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 2);
        }

        public async Task<int> RollD3(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 3);
        }

        public async Task<int> RollD4(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 4);
        }

        public async Task<int> RollD6(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 6);
        }

        public async Task<int> RollD8(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 8);
        }

        public async Task<int> RollD10(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 10);
        }

        public async Task<int> RollD12(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 12);
        }

        public async Task<int> RollD20(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 20);
        }

        public async Task<int> RollD66()
        {
            var randomGenerator = new Random();
            return (randomGenerator.Next(1, 7) * 10) + randomGenerator.Next(1, 7);
        }

        public async Task<int> RollD100(int numberOfDice = 1)
        {
            return RollNormalDice(numberOfDice, 1, 100);
        }

        private int RollNormalDice(int numberOfDice, int minNumber, int maxNumber)
        {
            var randomGenerator = new Random();
            var result = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                result += randomGenerator.Next(minNumber, maxNumber + 1);
            }

            return result;
        }

        private async Task<int> DoRollLogic(DiceType diceType, int numberOfDice)
        {
            switch (diceType.Type)
            {
                case Die.D2:
                    return await RollD2(numberOfDice);
                case Die.D3:
                    return await RollD3(numberOfDice);
                case Die.D4:
                    return await RollD4(numberOfDice);
                case Die.D6:
                    return await RollD6(numberOfDice);
                case Die.D8:
                    return await RollD8(numberOfDice);
                case Die.D10:
                    return await RollD10(numberOfDice);
                case Die.D12:
                    return await RollD12(numberOfDice);
                case Die.D20:
                    return await RollD20(numberOfDice);
                case Die.D66:
                    return await RollD66();
                case Die.D100:
                    return await RollD100(numberOfDice);
            }

            return -1;
        }
    }
}
