/*
 * Математическая библиотека
 * Динамически загружаемая сборка
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/


using System;

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
			if(Math.Abs(b - 0.0) > double.Epsilon)
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
			return (Math.Abs(a - 1.0) < double.Epsilon) ? 1 : a * Factorial(a - 1);
		}


		/// <summary>
		/// Вычислет квадратный корень
		/// </summary>
		/// <param name="a">аргумент</param>		
		/// <returns>результат вычисления</returns>
		private static double Sqrt(double a)
		{
			if(a >= 0)
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
						return Summ(double.Parse(expressionItems[firstArgumentIndex]),
							double.Parse(expressionItems[secondArgumentIndex]));
					}

				case "difference":
					{
						return Difference(double.Parse(expressionItems[firstArgumentIndex]),
							double.Parse(expressionItems[secondArgumentIndex]));
					}

				case "multiplication":
					{
						return Multiplication(double.Parse(expressionItems[firstArgumentIndex]),
							double.Parse(expressionItems[secondArgumentIndex]));
					}

				case "division":
					{
						return Division(double.Parse(expressionItems[firstArgumentIndex]),
							double.Parse(expressionItems[secondArgumentIndex]));
					}

				case "factorial":
					{
						return Factorial(double.Parse(expressionItems[firstArgumentIndex]));
					}

				case "sqrt":
					{
						return Sqrt(double.Parse(expressionItems[firstArgumentIndex]));
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
