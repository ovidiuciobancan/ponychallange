namespace PonyChallange.UI.Inputs
{
	public class DifficultyInput : Input<int>
	{
		protected override string ErrorMessage => "Difficulty should be between 0 and 10";

		protected override string InputName => "Difficulty";

		protected override bool IsValid(int value) => value >= 0 && value <= 10;

		protected override bool TryConvertValue(string input, out int value) => int.TryParse(input, out value);
	}
}
