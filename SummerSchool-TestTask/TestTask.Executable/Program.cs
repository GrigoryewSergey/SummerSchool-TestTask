/*
 * Программа, выполняющая  загрузку сборки и вызывающая ее методы
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace TestTask.Executable
{
	public class Program
	{
		/// <summary>
		/// Список имен сборок, которые находятся в папке и реализуют заданные интерфейс
		/// </summary>
		List<string> pluginsList;

		/// <summary>
		/// Имя интерфейса, который должен реализовавыть класс из сборки
		/// </summary>
		private string interfaceName = "IComputable";

		/// <summary>
		/// Имя метода, который должен содержаться в классе, реализующем интерфейс interfaceName
		/// </summary>
		private string methodName = "Compute";

		/// <summary>
		/// Комадна пользователя для выхода
		/// </summary>
		private string exitCommand = "exit";

		/// <summary>
		/// Объект, реализующий необходимый интерфейс
		/// </summary>
		object implementsObject = null;

		/// <summary>
		/// Метод, который содержит каждый класс, реализующий интерфейс
		/// </summary>
		MethodInfo implementsMethod = null;

		/// <summary>
		/// Конструктор класса
		/// </summary>
		public Program()
		{
			pluginsList = new List<string>();
		}


		/// <summary>
		/// Использование метода из загруженнной сборки
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>резултат вычисления</returns>
		public double Compute(string expression)
		{
			return (double)implementsMethod.Invoke(implementsObject, new object[] { expression });
		}


		/// <summary>
		/// Обработка комманд от пользователя
		/// Программа выполняется, пока пользователь не введет "exit"
		/// </summary>
		public void ProcessUserSession()
		{
			string expression = "";
			double result = double.NaN;

			do
			{
				try
				{
					expression = Console.ReadLine();

					if(expression != exitCommand)
					{
						result = Compute(expression);

						if(!double.IsNaN(result))
						{
							Console.WriteLine("{0} equal {1}", expression, result);
						}
						else
						{
							Console.WriteLine("not supported command");
						}
					}
				}
				catch(DivideByZeroException e)
				{
					Console.WriteLine(e.Message);
				}
				catch(ArgumentException e)
				{
					Console.WriteLine(e.Message);
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}

			} while(expression != exitCommand);
		}


		/// <summary>
		/// Загружает все сборки из папки и проверяет на предмет реализации интерфейса
		/// </summary>
		/// <returns>число подходящих сборок</returns>
		public int LoadPlugins()
		{
			string[] pluginsAssemblyName = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");

			foreach(string assemblyName in pluginsAssemblyName)
			{
				try
				{
					Assembly assembly = Assembly.Load(Path.GetFileNameWithoutExtension(assemblyName));

					if(assembly != null)
					{
						Type[] assemblysTypes = assembly.GetTypes();

						foreach(Type type in assemblysTypes)
						{
							if(type.GetInterface(interfaceName, true) != null)
							{
								pluginsList.Add(Path.GetFileNameWithoutExtension(assemblyName));
							}
						}
					}
				}
				catch(Exception e)
				{
					Console.WriteLine("Не удалось загрузить сборку\n" + e.Message);
				}
			}

			return pluginsList.Count;
		}


		/// <summary>
		/// Отображает список доступных для использования сборок
		/// </summary>
		public void DisplayPlugins()
		{
			if(pluginsList.Count == 0)
			{
				Console.WriteLine("Плагины не загружены");
			}
			else
			{
				for(int i = 0; i < pluginsList.Count; i++)
				{
					Console.WriteLine("{0}) {1}", i, pluginsList[i]);
				}
			}
		}


		/// <summary>
		/// Выбирает сборку из списка доступных
		/// </summary>
		/// <param name="pluginNumber">номер сборки</param>
		/// <returns>была ли выбрана сборка</returns>
		public bool SelectPlugin(int pluginNumber)
		{
			if(pluginNumber >= 0 && pluginNumber < pluginsList.Count)
			{
				Assembly assembly = Assembly.Load(pluginsList[pluginNumber]);

				if(assembly != null)
				{
					foreach(Type type in assembly.GetTypes())
					{
						if(type.GetInterface(interfaceName, true) != null)
						{
							implementsObject = Activator.CreateInstance(type);

							implementsMethod = type.GetMethod(methodName);

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