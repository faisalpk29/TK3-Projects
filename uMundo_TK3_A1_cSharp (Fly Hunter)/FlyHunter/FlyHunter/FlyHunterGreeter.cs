using org.umundo.core;

namespace FlyHunter
{
	class FlyHunterGreeter : Greeter
	{
		private string Username;
		public delegate void UpdateScoreLocalDelegate();
		public event UpdateScoreLocalDelegate UpdateScoreLocal;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlyHunterGreeter"/> class.
		/// </summary>
		/// <param name="username">The username of greeter.</param>
		public FlyHunterGreeter(string username)
		{
			this.Username = username;
		}

		/// <summary>
		/// Welcomes the specified publisher.
		/// </summary>
		/// <param name="pub">The publisher.</param>
		/// <param name="subStub">The subscriber stub.</param>
		public override void welcome(Publisher pub, SubscriberStub subStub)
		{
			Message greeting = Message.toSubscriber(subStub.getUUID());
			greeting.putMeta("participant", Username + ";" + Globals.Score.ToString());
			greeting.putMeta("subscriber", Globals.sub.getUUID());
			pub.send(greeting);
		}

		/// <summary>
		/// Farewells the specified publisher and removes the users who exited.
		/// </summary>
		/// <param name="pub">The publisher.</param>
		/// <param name="subStub">The subscriber stub.</param>
		public override void farewell(Publisher pub, SubscriberStub subStub)
		{
			if (Globals.Participants.ContainsKey(subStub.getUUID()))
			{
				string leftUser = Globals.Participants[subStub.getUUID()];
				int index = Globals.Players.Names.IndexOf(leftUser.Split(';')[0]);

				//Deleting the Extras (Users and participants)
				Globals.Players.Scores.RemoveAt(index);
				Globals.Players.Names.RemoveAt(index);
				Globals.Participants.Remove(subStub.getUUID());

				UpdateScoreLocal();
			}
		}
	}
}
