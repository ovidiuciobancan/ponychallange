using System.Linq;
using System.Collections.Generic;
using PonyChallange.Game.Models;
using PonyChallange.Game.Interfaces;
using PonyChallange.Game.Constants;
using PonyChallange.Game.Extensions;

namespace PonyChallange.Game.Strategies
{
	/// <summary>
	/// BFS strategy, find any possible path
	/// </summary>
	public class BreadthFirstSearchStrategy : IPathfindingStrategy
	{
		public string GetMove(Maze maze)
		{
			// get graph data structure 
			var graph = maze.GetGraph();
			
			// compute path from endpoint to pony with BFS
			var path = GetPath(graph, maze.PonyPosition, maze.EndpointPosition);
			
			// convert path into array of directions
			var moves = maze.GetMoves(path);

			// return the first move in array
			// if domokun is blocking the way (there is no path), try to stay away from it! 
			// hoping that there will be a path in the future
			return moves.FirstOrDefault() ?? FarthestFromDomokunMove(maze, graph);
		}

		private int[] GetPath(Dictionary<int, HashSet<int>> graph, int source, int destination)
		{
			var path = new List<int>();
			// queue for unvisited nodes in the graph
			var frontier = new Queue<int>();
			// keep a dictionary with discovered edges
			var cameFrom = new Dictionary<int, int>();

			// add starting node
			frontier.Enqueue(source);

			//while there is no unvisited node
			while(frontier.Any())
			{
				//get first unvisited node in the queue
				var current = frontier.Dequeue();
				
				//if we reached destination, stop
				if (current == destination) 
					break;
				
				var neighbours = graph[current];
				foreach(var next in neighbours)
				{
					//check if node is already visited
					if(!cameFrom.ContainsKey(next))
					{
						// add undiscovered node
						frontier.Enqueue(next);
						// add the edge between current and next
						cameFrom[next] = current;
					}
				}
			}

			// add endpoint
			path.Add(destination);
			while(destination != source)
			{
				//if endpoint was not descovered then return empty path
				if (!cameFrom.ContainsKey(destination)) 
					return new int[0];
				path.Add(cameFrom[destination]);
				destination = cameFrom[destination];
			}

			return path.ToArray();
		}

		private string FarthestFromDomokunMove(Maze maze, Dictionary<int, HashSet<int>> graph)
		{
			// consider domokun connected to the pony 
			foreach(var neighbour in graph[maze.DomokunPosition])
			{
				graph[neighbour].Add(maze.DomokunPosition);
			}

			var max = 0;
			var move = Moves.STAY;
			var neighbours = graph[maze.PonyPosition];

			//get pony's farthest neighbour from domokun 
			foreach (var neighbour in neighbours)
			{
				var currentPath = GetPath(graph, neighbour, maze.DomokunPosition);
				//select move if this is the longest path between pony's neighbour and domokun
				// 
				if(max < currentPath.Length)
				{
					max = currentPath.Length;
					move = maze.GetDirection(maze.PonyPosition, neighbour);
				}
			}

			return move;
		}
	}
}