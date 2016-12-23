using System;
namespace Adaptation
{
	public class BaseObject : MonoBehavior
	{
		private readonly int id = Utilities.GetRandomId();

		public int GetId()
		{
			return id;
		}
	}
}
