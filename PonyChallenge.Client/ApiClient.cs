using System;
using System.Net.Http;
using System.Threading.Tasks;
using PonyChallange.Client.Models;
using PonyChallange.Client.Extensions;

namespace PonyChallange.Client
{
	public class ApiClient
	{
		//TODO move to configuration file
		public const string URL = "https://ponychallenge.trustpilot.com/pony-challenge/";

		private readonly HttpClient _httpClient;

		public ApiClient()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(URL);
		}

		/// <summary>
		/// Creates a new maze setup 
		/// </summary>
		/// <param name="model"></param>
		/// <returns>Id of the maze</returns>
		public async Task<Guid> CreateMazeAsync(MazeCreateRequestModel model)
		{
			var response = await _httpClient.PostAsync("maze", model.ToJsonContent());
			var maze = await response.FromJsonContentAsync<MazeCreateResponseModel>();
			return maze.Id;
		}

		/// <summary>
		/// Gets maze state
		/// </summary>
		/// <param name="mazeId"></param>
		/// <returns></returns>
		public async Task<MazeStateResponseModel> GetMazeStateAsync(Guid mazeId)
		{
			var response = await _httpClient.GetAsync($"maze/{mazeId}");
			return await response.FromJsonContentAsync<MazeStateResponseModel>();
		}

		/// <summary>
		/// Sends player's move to the server
		/// </summary>
		/// <param name="mazeId"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<MazeMoveResponseModel> MoveAsync(Guid mazeId, MazeMoveRequestModel model)
		{
			var response = await _httpClient.PostAsync($"maze/{mazeId}", model.ToJsonContent());
			return await response.FromJsonContentAsync<MazeMoveResponseModel>();
		}

		/// <summary>
		/// Gets string representation of the maze 
		/// </summary>
		/// <param name="mazeId"></param>
		/// <returns></returns>
		public async Task<string> PrintAsync(Guid mazeId)
		{
			var response = await _httpClient.GetAsync($"maze/{mazeId}/print");
			return await response.Content.ReadAsStringAsync();
		}
	}
}
