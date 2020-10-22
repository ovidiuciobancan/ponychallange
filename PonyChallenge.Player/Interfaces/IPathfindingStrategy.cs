using PonyChallange.Game.Models;

namespace PonyChallange.Game.Interfaces
{
	/// <summary>
	/// Path finding strategy interface
	/// </summary>
	public interface IPathfindingStrategy
	{
		/// <summary>
		/// Strategy logic for the next move 
		/// </summary>
		/// <param name="maze"></param>
		/// <returns></returns>
		string GetMove(Maze maze);
	}
}
