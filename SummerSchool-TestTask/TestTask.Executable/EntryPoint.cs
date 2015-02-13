namespace TestTask.Executable
{
	using System;

	static class EntryPoint
	{
		private static void Main()
		{
			var calculator = new Calculator();

			calculator.LoadPlugins();

			calculator.DisplayPlugins();

			try
			{
				Console.Write("Номер плагина: ");

				var inputString = Console.ReadLine();

				if (inputString != null)
				{
					var pluginNumber = int.Parse(inputString);

					if (calculator.SelectPlugin(pluginNumber))
					{
						calculator.ProcessUserSession();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Плагин выбран не верно\n" + e.Message);
			}
		}
	}
}