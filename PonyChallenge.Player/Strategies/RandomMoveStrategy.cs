using System;
using PonyChallange.Game.Models;
using PonyChallange.Game.Constants;
using PonyChallange.Game.Interfaces;

namespace PonyChallange.Game.Strategies
{
	public class RandomMoveStrategy : IPathfindingStrategy
	{
		private string[] _moveTypes => new[] { Moves.NORTH, Moves.WEST, Moves.SOUTH, Moves.EAST, Moves.STAY };

		public string GetMove(Maze maze) => _moveTypes[new Random().Next(_moveTypes.Length)];
	}
}
