using System;
using PonyChallange.Game.Models;
using PonyChallange.Game.Constants;
using PonyChallange.Game.Interfaces;

namespace PonyChallange.UI
{
	public class ConsoleGameDisplay : IGameDisplay
	{
		public void Render(GameScene gameReport)
		{
			Console.Clear();
			Console.WriteLine(gameReport.MazePrint);

			switch (gameReport.GameState)
			{
				case GameStates.WON:
					Console.BackgroundColor = ConsoleColor.Green;
					break;
				case GameStates.OVER:
					Console.BackgroundColor = ConsoleColor.Red;
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Black;
					break;
			}

			Console.WriteLine(gameReport.ServerMessage);
			Console.BackgroundColor = ConsoleColor.Black;
		}
	}
}
