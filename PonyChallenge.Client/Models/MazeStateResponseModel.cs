using Newtonsoft.Json;

namespace PonyChallange.Client.Models
{
	public class MazeStateResponseModel
	{
		[JsonProperty("pony")]
		public int[] Pony { get; set; }

		[JsonProperty("domokun")]
		public int[] Domokun { get; set; }

		[JsonProperty("end-point")]
		public int[] EndPoint { get; set; }

		[JsonProperty("size")]
		public int[] Size { get; set; }

		[JsonProperty("data")]
		public string[][] Data { get; set; }
	}
}
