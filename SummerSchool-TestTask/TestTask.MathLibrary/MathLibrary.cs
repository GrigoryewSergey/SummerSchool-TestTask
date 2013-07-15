/*
 * Математическая библиотека
 * Динамически загружаемая сборка
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/


using System;
using System.Globalization;

namespace TestTask.MathLibraryNamespace
{
	public class MathLibrary : IComputable
	{
		/// <summary>
		/// Вычислет сумму
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Summ(double a, double b)
		{
			return a + b;
		}


		/// <summary>
		/// Вычислет разность
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Difference(double a, double b)
		{
			return a - b;
		}


		/// <summary>
		/// Вычислет произведение
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Multiplication(double a, double b)
		{
			return a * b;
		}


		/// <summary>
		/// Вычислет отношение
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Division(double a, double b)
		{
			if(b != 0.0)
			{
				return a / b;
			}

			throw new DivideByZeroException();
		}


		/// <summary>
		/// Вычислет факториал
		/// </summary>
		/// <param name="a">аргумент</param>		
		/// <returns>результат вычисления</returns>
		private static double Factorial(double a)
		{
			return (a == 1.0) ? 1 : a * Factorial(a - 1);
		}


		/// <summary>
		/// Вычислет квадратный корень
		/// </summary>
		/// <param name="a">аргумент</param>		
		/// <returns>результат вычисления</returns>
		private static double Sqrt(double a)
		{
			if(a >= 0.0)
			{
				return Math.Sqrt(a);
			}

			throw new ArgumentException();
		}


		/// <summary>
		/// Выбирает математичекскую оперцию в соответствии с выражением
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>результат вычисления</returns>
		private double ChangeMathOperation(string expression)
		{
			const int operationIndex = 0;
			const int firstArgumentIndex = 1;
			const int secondArgumentIndex = 2;

			string[] expressionItems = expression.Split(' ');

			string operation = expressionItems[operationIndex];

			switch(operation)
			{
				case "summ":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
						double b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

						return Summ(a, b);
					}

				case "difference":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
						double b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

						return Difference(a, b);
					}

				case "multiplication":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
						double b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

						return Multiplication(a, b);
					}

				case "division":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
						double b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

						return Division(a, b);
					}

				case "factorial":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);

						return Factorial(a);
					}

				case "sqrt":
					{
						double a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);

						return Sqrt(a);
					}

				default:
					{
						return double.NaN;
					}
			}
		}


		/// <summary>
		/// Реализация интерфейса IComputable
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>результат вычисления</returns>
		public double Compute(string expression)
		{
			return ChangeMathOperation(expression);
		}
	}
}
