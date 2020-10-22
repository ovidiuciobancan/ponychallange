using PonyChallange.Game.Models;

namespace PonyChallange.Game.Interfaces
{
	/// <summary>
	/// Game display interface
	/// </summary>
	public interface IGameDisplay
	{
		/// <summary>
		/// Renders scene of the game
		/// </summary>
		/// <param name="gameReport"></param>
		void Render(GameScene gameReport);
	}
}
