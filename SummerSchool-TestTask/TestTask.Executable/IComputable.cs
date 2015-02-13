namespace TestTask.Executable
{
	/// <summary>
	///     Интерфейс, который должен реализовывать класс из динамически загружаемой сборки
	/// </summary>
	public interface IComputable
	{
		/// <summary>
		///     Метод, для вычисления выражени
		/// </summary>
		/// <param name="expression">выражение в виде строки</param>
		/// <returns>результат вычисления выражения</returns>
		double Compute(string expression);
	}
}