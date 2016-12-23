using System;
using System.Collections.Generic;

namespace Adaptation
{
	public class AchieverManager
	{
		private static AchieverManager achieverMgr;

		private int challengeScore;
		public List<Challenge> challenges;

		public static AchieverManager instance
		{
			get
			{
				if (!achieverMgr)
				{
					achieverMgr = FindObjectOfType(typeof(AchieverManager)) as AchieverManager;

					if (!achieverMgr)
					{
						Debug.LogError("There needs to be one active AchieverManager script on a GameObject in your scene.");
					}
					else
					{
						achieverMgr.Init();
					}
				}

				return achieverMgr;
			}
		}

		void Init()
		{

		}

		public static void CompleteChallenge(Challenge challenge)
		{
			instance.challengeScore += challenge.score;
			challenge.Teardown();

			InitializeNextChallenge(challenge);
		}

		public static void InitializeNextChallenge(Challenge challenge)
		{
			int idx = instance.challenges.LastIndexOf(challenge);

			if (++idx == instance.challenges.Count)
			{
				//TODO: Completed all challenges
			}
			else
			{
				instance.challenges[idx].Setup();
			}
		}
	}
}
