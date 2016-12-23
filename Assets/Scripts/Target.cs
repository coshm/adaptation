using System;
namespace Adaptation
{
	public class Target : BaseObject
	{
		public Challenge challenge;
		public Animator animator;

		void OnCollisionEnter(Collision col)
		{
			if (Utilities.BALL.Equals(col.tag))
			{
				int ballId = col.gameObject.GetComponent<Ball>().GetId();
				if (Utilities.GOAL.Equals(gameObject.tag))
				{
					challenge.ScoreGoal(ballId);
					col.gameObject.Destroy();
				}
				else
				{
					challenge.HitTarget(ballId, GetId());
				}
			}
		}

		public void Deploy ()
		{
			// Animate into place
		}

		public void Withdraw ()
		{
			// Animate out of the scene
		}
	}
}
