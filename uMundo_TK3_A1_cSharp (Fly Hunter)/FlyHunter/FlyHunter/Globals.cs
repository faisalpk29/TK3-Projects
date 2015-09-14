
using System.Collections.Generic;
namespace FlyHunter
{
	/// <summary>
	/// Global variables/properties
	/// </summary>
	public static class Globals
	{
		public static int Score = 0;
		public static string Username = string.Empty;
		public static Dictionary<string, string> Participants = new Dictionary<string, string>();
		public static org.umundo.core.Subscriber sub;
		public static FlyHuntMessage Players;
	}
}
