using System.Linq;
using System.Collections.Generic;
using PonyChallange.Game.Models;
using PonyChallange.Game.Constants;
using System;

namespace PonyChallange.Game.Extensions
{
	/// <summary>
	/// Maze extension methods
	/// </summary>
	public static class MazeExtensions
	{
		/// <summary>
		/// Gets graph data structure from maze
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		public static Dictionary<int, HashSet<int>> GetGraph(this Maze maze)
		{
			var map = maze.Map;
			var domokun = maze.DomokunPosition;
			var result = new Dictionary<int, HashSet<int>>();

			for (int i = 0; i < maze.Map.Length; i++)
			{
				//create list of neighbors
				result[i] = new HashSet<int>();
				
				//get up, down, left, right indexes from a linear matrix
				var north = maze.North(i);
				var south = maze.South(i);
				var west = maze.West(i);
				var east = maze.East(i);

				// if current node does not has walls 
				// and neighbors don't have walls 
				// and domokun not in there  
				if (north.HasValue && !map[i].Contains(Moves.NORTH) && north != domokun)
				{
					result[i].Add(north.Value);
				}
				
				if(south.HasValue && !map[south.Value].Contains(Moves.NORTH) && south != domokun)
				{
					result[i].Add(south.Value);
				}

				if(west.HasValue && !map[i].Contains(Moves.WEST) && west != domokun)
				{
					result[i].Add(west.Value);
				}

				if(east.HasValue && !map[east.Value].Contains(Moves.WEST) && east != domokun)
				{
					result[i].Add(east.Value);
				}
			}

			return result;
		}

		/// <summary>
		/// Get top index in a linear matrix
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static int? North(this Maze maze, int index)
		{
			var result = index - maze.Width;
			return result > 0 ? result : (int?)null;
		}

		/// <summary>
		/// Gets bottom index in a linear matrix 
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static int? South(this Maze maze, int index)
		{
			var result = index + maze.Width;
			return result < maze.Width * maze.Height ? result : (int?)null;
		}

		/// <summary>
		/// Gets left index in a linear matrix
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static int? West(this Maze maze, int index)
		{
			return index % maze.Width != 0 ? index - 1 : (int?)null;
		}

		/// <summary>
		/// Gets right index in a linear matrix 
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static int? East(this Maze maze, int index)
		{
			return index % maze.Width != maze.Width - 1 ? index + 1 : (int?)null;
		}

		/// <summary>
		/// Gets move direction between two indexes
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="index1"></param>
		/// <param name="index2"></param>
		/// <returns></returns>
		public static string GetDirection(this Maze maze, int index1, int index2)
		{
			//get the distance between indexes
			var delta = index1 - index2;

			//map each difference to a direction
			var positionMappings = new Dictionary<int, string>()
			{
				{ 1, Moves.WEST },
				{ -1, Moves.EAST },
				{ maze.Width, Moves.NORTH },
				{ -maze.Width, Moves.SOUTH }
			};

			if (!positionMappings.ContainsKey(delta))
				throw new Exception($"Index {index1} and index {index2} cannot be neighbors");

			return positionMappings[delta];
		}

		/// <summary>
		/// Reconstructs the way back found by the strategy
		/// </summary>
		/// <param name="maze"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] GetMoves(this Maze maze, int[] path)
		{
			//path represents the list of indexes from the endpoint to pony position
			//we need to return back a list of directions from pony to endpoint
			var result = new List<string>();
			if (!path.Any()) return new string[0];

			for (int i = 1; i < path.Length; i++)
			{
				//path is reversed so we need to compute the opposite direction
				var direction = maze.GetDirection(path[i], path[i-1]);
				//reverse the path by inserting from 0
				result.Insert(0, direction);
			}

			return result.ToArray();
		}
	}
}
