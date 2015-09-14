
using System.Collections.Generic;
namespace FlyHunter
{
	public class FlyHuntMessage
	{
		public int xPos { get; set; }
		public int yPos { get; set; }
		public List<string> Names = new List<string>();
		public List<string> Scores = new List<string>();
	}
}
