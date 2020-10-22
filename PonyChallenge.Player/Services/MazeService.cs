using System;
using System.Threading.Tasks;
using PonyChallange.Client;
using PonyChallange.Client.Models;
using PonyChallange.Game.Models;
using PonyChallange.Game.Extensions;

namespace PonyChallange.Game.Services
{
	/// <summary>
	/// Wapper class for api client
	/// </summary>
	public class MazeService
	{
		private readonly ApiClient _client;

		public MazeService()
		{
			_client = new ApiClient();
		}

		/// <summary>
		/// Creates a new maze based on provided condiguration
		/// </summary>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public async Task<Guid> CreateMazeAsync(MazeConfiguration configuration)
		{
			var model = configuration.Map();
			return await _client.CreateMazeAsync(model);
		}

		/// <summary>
		/// Gets current state of the maze
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Maze> GetMazeAsync(Guid id)
		{
			var model = await _client.GetMazeStateAsync(id);
			return model.Map();
		}

		/// <summary>
		/// Gets string representation of the maze
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> PrintMazeAsync(Guid id)
		{
			return await _client.PrintAsync(id);
		}

		/// <summary>
		/// Move player based in direction provided
		/// </summary>
		/// <param name="id"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		public async Task<MoveResult> MoveAsync(Guid id, string direction)
		{
			var model = new MazeMoveRequestModel { Direction = direction };
			var result = await _client.MoveAsync(id, model);
			return result.Map();
		}
	}
}
