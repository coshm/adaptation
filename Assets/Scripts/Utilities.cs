using System;
namespace Adaptation
{
	public class Utilities
	{
		public const string BALL = "ball";
		public const string GOAL = "goal";

		private static readonly Random random = GetRandom();
		private static Random GetRandom()
		{
			TimeSpan timeSpan = DateTime.Now - DateTime.MinValue;
			int seed = (int) (timeSpan.TotalSeconds % int.MaxValue);
			return new Random(seed);
		}
			
		public static int GetRandomId()
		{
			return random.Next(int.MaxValue);
		}
	}
}
