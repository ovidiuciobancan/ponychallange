using System;
using Newtonsoft.Json;

namespace PonyChallange.Client.Models
{
	public class MazeCreateResponseModel
	{
		[JsonProperty("maze_id")]
		public Guid Id { get; set; } 
	}
}
