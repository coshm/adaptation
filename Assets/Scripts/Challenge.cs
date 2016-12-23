using System;
using System.Collections.Generic;

namespace Adaptation
{
	public class Challenge : BaseObject
	{
		public int score;

		// Last Target in List is the goal.
		public List<Target> targets;

		private Dictionary<int, bool[]> ballProgress;
		private int goalId;

		void Awake ()
		{
			ballProgress = new Dictionary<int, bool[]>();
			if (targets != null && targets.Count >= 0)
			{
				goalId = targets[targets.Count - 1].GetId();
			}
		}

		void Setup ()
		{
			EventManager.StartListening("PickUpBall", ClearBallProgress);
			//TODO: Enable all targets + goal
		}

		void Teardown ()
		{
			EventManager.StopListening("PickUpBall", ClearBallProgress);
			//TODO: Disable all targets + goal
		}

		public void HitTarget(int ballId, int targetId)
		{
			bool[] progress = null;
			ballProgress.TryGetValue(ballId, out progress);
			if (progress == null)
			{
				progress = new bool[targets.Count];
			}

			int idx = targets.FindIndex(
				delegate (Target target)
				{
					return target.GetId() == targetId;
				});

			progress[idx] = true;
			ballProgress[ballId] = progress;
		}

		public void ScoreGoal(int ballId)
		{
			bool[] progress = null;
			ballProgress.TryGetValue(ballId, out progress);
			if (progress != null)
			{
				bool allTargetsHit = true;
				foreach (bool target in progress)
				{
					allTargetsHit &= target;
					if (!allTargetsHit)
					{
						break;
					}
				}

				if (allTargetsHit)
				{
					AchieverManager.CompleteChallenge(this);
					return;
				}
			}

			// If not all targets have been hit
			ClearBallProgress(ballId);
		}

		public void ClearBallProgress(int ballId)
		{
			ballProgress.Remove(ballId);
		}
	}
}
