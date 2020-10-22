using PonyChallange.Client.Models;
using PonyChallange.Game.Models;

namespace PonyChallange.Game.Extensions
{
	/// <summary>
	/// Mapping extension methods 
	/// </summary>
	public static class MappingExtensions
	{
		/// <summary>
		/// Maps maze state response to maze model 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public static Maze Map(this MazeStateResponseModel model) => new Maze
		{
			Width = model.Size[0],
			Height = model.Size[1],
			PonyPosition = model.Pony[0],
			DomokunPosition = model.Domokun[0],
			EndpointPosition = model.EndPoint[0],
			Map = model.Data
		};

		/// <summary>
		/// Maps maze configuration model to maze create request model
		/// </summary>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static MazeCreateRequestModel Map(this MazeConfiguration configuration) => new MazeCreateRequestModel
		{
			Width = configuration.Width,
			Height = configuration.Height,
			PlayerName = configuration.PlayerName,
			Difficulty = configuration.Difficulty
		};

		/// <summary>
		/// Maps move response to move result model
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public static MoveResult Map(this MazeMoveResponseModel model) => new MoveResult
		{
			GameState = model.State,
			ActionResult = model.StateResult
		};
	}
}
