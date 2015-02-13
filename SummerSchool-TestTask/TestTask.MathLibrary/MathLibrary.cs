namespace TestTask.MathLibraryNamespace
{
	using System;
	using System.Globalization;

	public class MathLibrary : IComputable
	{
		/// <summary>
		///		Точность, с которой сравниваются числа
		/// </summary>
		private const double Accuracy = 0.0000000001;

		/// <summary>
		///     Реализация интерфейса IComputable
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>результат вычисления</returns>
		public double Compute(string expression)
		{
			return ChangeMathOperation(expression);
		}

		/// <summary>
		///     Вычислет сумму
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Summ(double a, double b)
		{
			return a + b;
		}


		/// <summary>
		///     Вычислет разность
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Difference(double a, double b)
		{
			return a - b;
		}


		/// <summary>
		///     Вычислет произведение
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Multiplication(double a, double b)
		{
			return a * b;
		}


		/// <summary>
		///     Вычислет отношение
		/// </summary>
		/// <param name="a">первый аргумент</param>
		/// <param name="b">второй аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Division(double a, double b)
		{
			if (Math.Abs(b) > Accuracy)
			{
				return a/b;
			}

			throw new DivideByZeroException();
		}


		/// <summary>
		///     Вычислет факториал
		/// </summary>
		/// <param name="a">аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Factorial(double a)
		{
			return (Math.Abs(a - 1.0) < Accuracy) ? 1.0 : a*Factorial(a - 1.0);
		}


		/// <summary>
		///     Вычислет квадратный корень
		/// </summary>
		/// <param name="a">аргумент</param>
		/// <returns>результат вычисления</returns>
		private static double Sqrt(double a)
		{
			if (a >= 0.0)
			{
				return Math.Sqrt(a);
			}

			throw new ArgumentException();
		}


		/// <summary>
		///     Выбирает математичекскую оперцию в соответствии с выражением
		/// </summary>
		/// <param name="expression">выражение для вычисления</param>
		/// <returns>результат вычисления</returns>
		private double ChangeMathOperation(string expression)
		{
			const int operationIndex = 0;
			const int firstArgumentIndex = 1;
			const int secondArgumentIndex = 2;

			var expressionItems = expression.Split(' ');

			var operation = expressionItems[operationIndex];

			switch (operation)
			{
				case "summ":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
					var b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

					return Summ(a, b);
				}

				case "difference":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
					var b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

					return Difference(a, b);
				}

				case "multiplication":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
					var b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

					return Multiplication(a, b);
				}

				case "division":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);
					var b = double.Parse(expressionItems[secondArgumentIndex], CultureInfo.InvariantCulture);

					return Division(a, b);
				}

				case "factorial":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);

					return Factorial(a);
				}

				case "sqrt":
				{
					var a = double.Parse(expressionItems[firstArgumentIndex], CultureInfo.InvariantCulture);

					return Sqrt(a);
				}

				default:
				{
					return double.NaN;
				}
			}
		}
	}
}