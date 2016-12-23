using System;
namespace Adaptation
{
	public class Goal : BaseObject
	{
		public Challenge challenge;

		void OnTriggerEnter(Collider col)
		{
			if (Utilities.BALL.Equals(col.tag))
			{
				int ballId = col.gameObject.GetComponent<Ball>().GetId();
				challenge.ScoreGoal(ballId);
			}
		}

		public void Deploy()
		{

		}

		public void Withdraw()
		{

		}
	}
}
