using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PonyChallange.Client.Extensions
{
	/// <summary>
	/// Http extension methods
	/// </summary>
	public static class HttpExtensions
	{
		/// <summary>
		/// Deserializes http content from response message
		/// Throws exception if status is not success 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message"></param>
		/// <returns></returns>
		public static async Task<T> FromJsonContentAsync<T>(this HttpResponseMessage response)
		{
			response.EnsureSuccessStatusCode();
			var stringContent = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(stringContent);
		}

		/// <summary>
		/// Creates http json content from object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static HttpContent ToJsonContent<T>(this T obj)
		{
			return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
		}
	}
}
