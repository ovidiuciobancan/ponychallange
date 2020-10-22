using Newtonsoft.Json;

namespace PonyChallange.Client.Models
{
	public class MazeMoveResponseModel
	{
		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("state-result")]
		public string StateResult { get; set; }
	}
}
