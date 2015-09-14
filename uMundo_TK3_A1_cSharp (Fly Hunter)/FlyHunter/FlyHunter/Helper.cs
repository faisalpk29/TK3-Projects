
namespace FlyHunter
{
	public static class Helper
	{

		/// <summary>
		/// Adds the score for a user.
		/// </summary>
		/// <param name="username">The username.</param>
		public static void AddScore(string username)
		{
			Globals.Players.Scores[Globals.Players.Names.IndexOf(username)] =
				(int.Parse(Globals.Players.Scores[Globals.Players.Names.IndexOf(username)]) + 1).ToString();
		}
	}
}
