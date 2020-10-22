namespace PonyChallange.UI.Inputs
{
	public class MazeDimensionInput : Input<int>
	{
		private readonly string _dimensionType;

		public MazeDimensionInput(string dimensionType)
		{
			_dimensionType = dimensionType;
		}

		protected override string ErrorMessage =>
			$"Maze {_dimensionType} should be between 15 and 25";

		protected override string InputName =>
			$"Maze {_dimensionType}";

		protected override bool IsValid(int value) => 
			value >= 15 && value <= 25;

		protected override bool TryConvertValue(string input, out int value) => int.TryParse(input, out value);
	}
}
