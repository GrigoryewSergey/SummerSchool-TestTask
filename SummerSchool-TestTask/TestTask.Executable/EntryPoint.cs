/*
 * Точка входа приложения
 * С этого метода начинается выполнение приложения
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/

using System;

namespace TestTask.Executable
{
	class EntryPoint
	{
		static void Main()
		{
			var program = new Program();

			// Загружаем сборки
			program.LoadPlugins();

			// Отображаем список подходящих сборок
			program.DisplayPlugins();

			try
			{
				// Предлагаем пользователю выбор конткретной сборки
				Console.Write("Номер плагина: ");

				var pluginNumber = int.Parse(Console.ReadLine());

				// Если сборка была выбрана
				if(program.SelectPlugin(pluginNumber))
				{
					// Обрабатывать команды пользователя
					program.ProcessUserSession();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Плагин выбран не верно\n" + e.Message);
			}
		}
	}
}
