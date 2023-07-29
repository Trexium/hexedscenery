namespace HexedSceneryWebsite.Services
{
    public interface IDiceRollService
    {
        int RollD6(int numberOfDice = 1);
        int RollD66();

    }

    public class DiceRollService : IDiceRollService
    {

        public int RollD6(int numberOfDice = 1)
        {
            var randomGenerator = new Random();
            var result = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                result += randomGenerator.Next(1, 7);
            }

            return result;
        }

        public int RollD66()
        {
            var randomGenerator = new Random();
            return (randomGenerator.Next(1, 7) * 10) + randomGenerator.Next(1, 7);
        }
    }
}
