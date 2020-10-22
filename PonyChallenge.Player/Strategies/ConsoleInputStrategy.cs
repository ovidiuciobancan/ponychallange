using System;
using System.Collections.Generic;
using PonyChallange.Game.Models;
using PonyChallange.Game.Interfaces;
using PonyChallange.Game.Constants;

namespace PonyChallange.Game.Strategies
{
	public class ConsoleInputStrategy : IPathfindingStrategy
	{
		// map pressed key to a direction
		private Dictionary<ConsoleKey, string> keyDirections = new Dictionary<ConsoleKey, string>()
		{
			{ ConsoleKey.UpArrow, Moves.NORTH },
			{ ConsoleKey.DownArrow, Moves.SOUTH },
			{ ConsoleKey.LeftArrow, Moves.WEST },
			{ ConsoleKey.RightArrow, Moves.EAST },
			{ ConsoleKey.Spacebar, Moves.STAY }
		};

		public string GetMove(Maze maze)
		{
			ConsoleKey key = default;
			//while user inputs valid key 
			while(!keyDirections.ContainsKey(key))
			{
				Console.WriteLine("Enter direction by pressing any arrow keys or space to stay");
				key = Console.ReadKey().Key;
			}

			return keyDirections[key];
		}
	}
}
