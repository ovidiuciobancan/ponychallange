using System.Linq;
using System.Collections.Generic;
using PonyChallange.Game.Interfaces;

namespace PonyChallange.UI.Inputs
{
	public class PlayerNameInput : Input<string>
	{
		private readonly Dictionary<string, (IPathfindingStrategy strategy, string description)> _availableOptions;

		public PlayerNameInput(Dictionary<string, (IPathfindingStrategy strategy, string description)> availableOptions)
		{
			_availableOptions = availableOptions;
		}

		protected override string ErrorMessage =>
			"Selection is not valid. Please select one of the displayed options";

		protected override string InputName =>
			$"Select player: \n{PlayersList}\n Player name";

		protected override bool IsValid(string value) => _availableOptions.ContainsKey(value);

		protected override bool TryConvertValue(string input, out string value)
		{
			value = input;
			return true;
		}

		private string PlayersList => string.Join($"\n", _availableOptions.Select((p, i) => $"\t{p.Key} - {p.Value.description}"));
	}
}
