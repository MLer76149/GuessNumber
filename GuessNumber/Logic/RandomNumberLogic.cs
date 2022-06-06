namespace GuessNumber.Logic
{
    public static class RandomNumberLogic
    {
        private static List<int> Guesses { get; set; } = new List<int>();
        private static Random rand = new Random();
        public static int RandomNumber = rand.Next(101);

        public static void GetRandomNumber()
        {
            RandomNumber =  rand.Next(101);
        }

        public static List<int> SaveNumber(int? guessedNumber)
        {
            if (guessedNumber != null)
            {
                Guesses.Add((int)guessedNumber);
            }

            return Guesses;
        }

        public static void ClearGuessesList()
        {
            Guesses.Clear();
        }
    }
}
