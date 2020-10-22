using System;

namespace PonyChallange.Game.Models
{
	public class Maze
	{
		public int Width { get; set; }
		public int Height { get; set; }
		
		public int PonyPosition { get; set; }
		public int DomokunPosition { get; set; }
		public int EndpointPosition { get; set; }
		public string[][] Map { get; set; }
	}
}
