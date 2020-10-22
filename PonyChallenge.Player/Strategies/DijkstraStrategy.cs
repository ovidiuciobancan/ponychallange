using System.Linq;
using System.Collections.Generic;
using PonyChallange.Utils.Collections;
using PonyChallange.Game.Models;
using PonyChallange.Game.Constants;
using PonyChallange.Game.Interfaces;
using PonyChallange.Game.Extensions;

namespace PonyChallange.Game.Strategies
{
	public class DijktraStrategy : IPathfindingStrategy
	{
		/// <summary>
		/// Get move using Dijktra path finding algorithm
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		public string GetMove(Maze maze)
		{
			// get graph data structure 
			var graph = maze.GetGraph();

			// compute path from endpoint to pony with BFS
			var path = GetPath(graph, maze.PonyPosition, maze.EndpointPosition);

			// convert path into array of directions
			var moves = maze.GetMoves(path);

			return moves.FirstOrDefault() ?? Moves.STAY;
		}

		private int[] GetPath(Dictionary<int, HashSet<int>> graph, int source, int destination)
		{
			var path = new List<int>();
			var frontier = new PriorityQueue<int>();
			var cameFrom = new Dictionary<int, int>();
			var costSoFar = new Dictionary<int, int>();
			
			frontier.Enqueue(source, 0);

			while(frontier.Count != 0)
			{
				var current = frontier.Dequeue();
				
				if (current == destination) 
					break;
				
				var neighbours = graph[current];

				foreach(var next in neighbours)
				{
					if (!costSoFar.ContainsKey(current))
						costSoFar[current] = 1;

					if (!costSoFar.ContainsKey(next))
						costSoFar[next] = 1;

					var newCost = costSoFar[current] + 1;
					// if node is undiscovered or we have a better cost
					if (!cameFrom.ContainsKey(next) || newCost < costSoFar[next])
					{
						costSoFar[next] = newCost;
						frontier.Enqueue(next, newCost);
						cameFrom[next] = current;
					}
				}
			}

			// add endpoint
			path.Add(destination);
			while (destination != source)
			{
				//if endpoint was not discovered then return empty path
				if (!cameFrom.ContainsKey(destination))
					return new int[0];
				path.Add(cameFrom[destination]);
				destination = cameFrom[destination];
			}

			return path.ToArray();
		}
	}
}
