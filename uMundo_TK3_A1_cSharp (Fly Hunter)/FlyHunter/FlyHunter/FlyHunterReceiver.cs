using org.umundo.core;

namespace FlyHunter
{
	class FlyHunterReceiver : Receiver
	{
		#region Delegates
		public delegate void RelocateFlyDelegate(int x, int y);
		public event RelocateFlyDelegate RelocateFly;

		public delegate void UpdateScoreLocalDelegate();
		public event UpdateScoreLocalDelegate UpdateScoreLocal;
		#endregion

		/// <summary>
		/// Receives the uMundo message.
		/// </summary>
		/// <param name="msg">The umundo core message.</param>
		public override void receive(org.umundo.core.Message msg)
		{

			if (msg.getMeta().ContainsKey("participant"))
			{
				//If greeting is received
				Globals.Participants.Add(msg.getMeta("subscriber"), msg.getMeta("participant"));
				Globals.Players.Names.Add(msg.getMeta("participant").Split(';')[0]);
				Globals.Players.Scores.Add(msg.getMeta("participant").Split(';')[1]);

				UpdateScoreLocal();
			}
			else
			{
				//Called when someone else scores
				Helper.AddScore((msg.getMeta("userName")));
				RelocateFly(int.Parse(msg.getMeta("xPos")), int.Parse(msg.getMeta("yPos")));
				UpdateScoreLocal();
			}
		}
	}
}
