namespace TestTask.Executable
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;

	public class Calculator
	{
		/// <summary>
		///     Имя интерфейса, который должен реализовавыть класс из сборки
		/// </summary>
		private const string InterfaceName = "IComputable";

		/// <summary>
		///     Имя метода, который должен содержаться в классе, реализующем интерфейс InterfaceName
		/// </summary>
		private const string MethodName = "Compute";

		/// <summary>
		///     Комадна пользователя для выхода
		/// </summary>
		private const string ExitCommand = "exit";

		/// <summary>
		///     Список имен сборок, которые находятся в папке и реализуют заданные интерфейс
		/// </summary>
		private readonly List<string> pluginsList;

		/// <summary>
		///     Метод, который содержит каждый класс, реализующий интерфейс
		/// </summary>
		private MethodInfo implementsMethod;

		/// <summary>
		///     Объект, реализующий необходимый интерфейс
		/// </summary>
		private object implementsObject;

		/// <summary>
		///     Конструктор класса
		/// </summary>
		public Calculator()
		{
			pluginsList = new List<string>();
		}


		/// <summary>
		///     Использование метода из загруженнной сборки
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>резултат вычисления</returns>
		public double Compute(string expression)
		{
			return (double) implementsMethod.Invoke(implementsObject, new object[] {expression});
		}


		/// <summary>
		///     Обработка команд от пользователя
		///     Программа выполняется, пока пользователь не введет "exit"
		/// </summary>
		public void ProcessUserSession()
		{
			var expression = "";

			do
			{
				try
				{
					expression = Console.ReadLine();

					if (expression != ExitCommand)
					{
						var result = Compute(expression);

						if (!double.IsNaN(result))
						{
							Console.WriteLine("{0} equal {1}", expression, result);
						}
						else
						{
							Console.WriteLine("not supported command");
						}
					}
				}
				catch (DivideByZeroException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			} while (expression != ExitCommand);
		}


		/// <summary>
		///     Загружает все сборки из папки и проверяет на предмет реализации интерфейса
		/// </summary>
		/// <returns>число подходящих сборок</returns>
		public int LoadPlugins()
		{
			var pluginsAssemblyName = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");

			foreach (var assemblyName in pluginsAssemblyName)
			{
				try
				{
					var assembly = Assembly.Load(Path.GetFileNameWithoutExtension(assemblyName));

					if (assembly != null)
					{
						var assemblysTypes = assembly.GetTypes();

						foreach (var type in assemblysTypes)
						{
							if (type.GetInterface(InterfaceName, true) != null)
							{
								pluginsList.Add(Path.GetFileNameWithoutExtension(assemblyName));
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Не удалось загрузить сборку\n" + e.Message);
				}
			}

			return pluginsList.Count;
		}


		/// <summary>
		///     Отображает список доступных для использования сборок
		/// </summary>
		public void DisplayPlugins()
		{
			if (pluginsList.Count == 0)
			{
				Console.WriteLine("Плагины не загружены");
			}
			else
			{
				for (var i = 0; i < pluginsList.Count; i++)
				{
					Console.WriteLine("{0}) {1}", i, pluginsList[i]);
				}
			}
		}


		/// <summary>
		///     Выбирает сборку из списка доступных
		/// </summary>
		/// <param name="pluginNumber">номер сборки</param>
		/// <returns>была ли выбрана сборка</returns>
		public bool SelectPlugin(int pluginNumber)
		{
			if (pluginNumber >= 0 && pluginNumber < pluginsList.Count)
			{
				var assembly = Assembly.Load(pluginsList[pluginNumber]);

				if (assembly != null)
				{
					foreach (var type in assembly.GetTypes())
					{
						if (type.GetInterface(InterfaceName, true) != null)
						{
							implementsObject = Activator.CreateInstance(type);

							implementsMethod = type.GetMethod(MethodName);

							return true;
						}
					}
				}
			}
			else
			{
				Console.WriteLine("Плагин выбран не верно");
			}

			return false;
		}
	}
}