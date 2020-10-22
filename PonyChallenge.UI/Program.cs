using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PonyChallange.Game;
using PonyChallange.Game.Models;
using PonyChallange.Game.Services;
using PonyChallange.Game.Interfaces;
using PonyChallange.Game.Strategies;
using PonyChallange.UI.Inputs;

namespace PonyChallange.UI
{
	class Program
	{
		static async Task Main(string[] args)
		{
			do
			{
				// prepare console for next game
				Console.Clear();
				// run game
				await RunNewAsync();
				Console.WriteLine("\nPress any key to play again! Escape to exit!\n");
			} while (Console.ReadKey().Key != ConsoleKey.Escape);
		}

		public static async Task RunNewAsync()
		{
			var mazeService = new MazeService();
			var playerStrategies = new Dictionary<string, (IPathfindingStrategy strategy, string description)>
			{
				{ "Fluttershy", (new RandomMoveStrategy(), "Makes random moves") },
				{ "Pinkie Pie", (new ConsoleInputStrategy(), "Takes input from keyboard (arrows and space)") },
				{ "Applejack", (new BreadthFirstSearchStrategy(), "Uses Breadth First Search algorithm") },
				{ "Rainbow Dash", (new DijktraStrategy(), "Uses Dijktra shortest path algorithm") }
			};
			
			var config = new MazeConfiguration()
			{
				PlayerName = new PlayerNameInput(playerStrategies).GetValue(),
				Width = new MazeDimensionInput("width").GetValue(),
				Height = new MazeDimensionInput("height").GetValue(),
				Difficulty = new DifficultyInput().GetValue()
			};

			var mazeId = await mazeService.CreateMazeAsync(config);
			var strategy = playerStrategies[config.PlayerName].strategy;
			var display = new ConsoleGameDisplay();
			var player = new Player(strategy, display);

			await player.RunAsync(mazeId);
		}
	}
}
