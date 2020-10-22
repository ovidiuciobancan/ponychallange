using System;

namespace PonyChallange.UI
{
	public abstract class Input<T>
	{
		protected abstract bool TryConvertValue(string input, out T value);
		protected abstract bool IsValid(T value);
		protected abstract string ErrorMessage { get; }
		protected abstract string InputName { get; }

		public T GetValue()
		{
			Console.Write($"\n{InputName}: ");
			
			var stringValue = Console.ReadLine();
			
			Console.WriteLine();

			if(!TryConvertValue(stringValue, out var value))
			{
				Error($"\n {stringValue} is not of type {typeof(T).Name}\n");
				return GetValue();
			}

			if(!IsValid(value))
			{
				Error(ErrorMessage);
				return GetValue();
			}

			return value;
		}

		private void Error(string message)
		{
			Console.WriteLine();
			Console.BackgroundColor = ConsoleColor.Red;
			Console.Write($"{message}");
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine();
		}
	}
}
