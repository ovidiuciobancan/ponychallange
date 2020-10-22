using System;
using System.Threading.Tasks;
using PonyChallange.Game.Models;
using PonyChallange.Game.Services;
using PonyChallange.Game.Constants;
using PonyChallange.Game.Interfaces;

namespace PonyChallange.Game
{
	public class Player
	{
		private readonly MazeService _service;
		private readonly IGameDisplay _gameDisplay;
		private readonly IPathfindingStrategy _strategy;
		
		public Player(IPathfindingStrategy strategy, IGameDisplay gameDisplay)
		{
			_strategy = strategy;
			_gameDisplay = gameDisplay;
			_service = new MazeService();
		}

		/// <summary>
		/// Run game by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task RunAsync(Guid id)
		{
			var scene = new GameScene() { GameState = GameStates.ACTIVE };
			
			while (scene.GameState == GameStates.ACTIVE)
			{
				// get maze state
				var maze = await _service.GetMazeAsync(id);
				// get string representation of maze
				scene.MazePrint = await _service.PrintMazeAsync(id);

				// render scene
				_gameDisplay.Render(scene);

				// use strategy to find best move
				var direction = _strategy.GetMove(maze);

				// move player and get action result
				var moveResult = await _service.MoveAsync(id, direction);

				//update report
				scene.GameState = moveResult.GameState;
				scene.ServerMessage = moveResult.ActionResult;
			}

			//render last scene
			_gameDisplay.Render(scene);
		}
	}
}
