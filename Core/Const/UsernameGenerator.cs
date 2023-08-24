namespace Core.Const
{
	public class UsernameGenerator
	{
		// A list of adjectives to use as prefixes
		private static readonly string[] Adjectives = new[]
		{
			"Awesome", "Brave", "Cool", "Daring", "Epic", "Funny", "Great", "Happy", "Incredible", "Jolly",
			"Kind", "Lucky", "Majestic", "Nice", "Optimistic", "Perfect", "Quick", "Radical", "Smart", "Talented",
			"Unique", "Valiant", "Wonderful", "Xtraordinary", "Yummy", "Zesty"
		};

		// A list of nouns to use as suffixes
		private static readonly string[] Numbers = new[]
		{
			"123", "321", "546", "654", "789", "987", "147", "258", "369", "741",
			"852", "963", "159", "753", "951", "357", "621", "56", "1", "014",
			"956", "652", "02", "011", "2", "3"
		};

		// A random number generator
		private static readonly Random Random = new();

		// A method that generates a random username
		public static string GenerateRandomUsername()
		{
			// Pick a random adjective from the list
			string adjective = Adjectives[Random.Next(Adjectives.Length)];

			// Pick a random noun from the list
			string noun = Numbers[Random.Next(Numbers.Length)];

			// Combine the adjective and the noun with a separator
			string separator = Random.Next(2) == 0 ? "_" : "_";
			string username = adjective + separator + noun;

			// Return the username
			return username;
		}
	}
}