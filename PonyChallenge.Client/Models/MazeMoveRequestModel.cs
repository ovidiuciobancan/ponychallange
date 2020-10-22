using Newtonsoft.Json;

namespace PonyChallange.Client.Models
{
	public class MazeMoveRequestModel
	{
		[JsonProperty("direction")]
		public string Direction { get; set; }
	}
}
