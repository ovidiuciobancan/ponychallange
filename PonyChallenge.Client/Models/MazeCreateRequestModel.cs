using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PonyChallange.Client.Models
{
	public class MazeCreateRequestModel
	{
		[JsonProperty("maze-width")]
		public int Width { get; set; }
		
		[JsonProperty("maze-height")]
		public int Height { get; set; }
	
		[JsonProperty("maze-player-name")]
		public string PlayerName { get; set; }

		[JsonProperty("difficulty")]
		public int Difficulty { get; set; }
	}
}
