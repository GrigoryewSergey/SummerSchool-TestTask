/*
 * Тесты для математической библиотеки
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/



using NUnit.Framework;
using System;
using TestTask.MathLibraryNamespace;

namespace TestTask.UnitTests
{
	[TestFixture]
	class MathLibraryUnitTests
	{
		private static readonly MathLibrary MathLibrary = new MathLibrary();
		private const int digitsAfterPoint = 6;

		[Test]
		[Category("MathLibrary")]
		[TestCase("summ 2.0 3.0", 5.0, TestName = "[MathLibrary] summ 2 3")]
		[TestCase("summ 22.2222 11.1111", 33.3333, TestName = "[MathLibrary] summ 22,2 11,1")]
		static public void SummTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		[TestCase("difference 5 3", 2, TestName = "[MathLibrary] difference 5 3")]
		[TestCase("difference 22.2 11.1", 11.1, TestName = "[MathLibrary] difference 22,2 11,1")]
		static public void DifferenceTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		[TestCase("multiplication 5 3", 15, TestName = "[MathLibrary] multiplication 5 3")]
		[TestCase("multiplication 0.2 0.3", 0.06, TestName = "[MathLibrary] multiplication 0,2 0,3")]
		static public void MultiplicationTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		[TestCase("division 15 3", 5, TestName = "[MathLibrary] division 15 3")]
		[TestCase("division 0.06 0.3", 0.2, TestName = "[MathLibrary] division 0,06 0,3")]
		[TestCase("division 15 0", 0, TestName = "[MathLibrary] division 15 0", ExpectedException = typeof(DivideByZeroException))]
		static public void DivisionTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		[TestCase("factorial 1", 1, TestName = "[MathLibrary] factorial 1")]
		[TestCase("factorial 5", 120, TestName = "[MathLibrary] factorial 5")]
		static public void FactorialTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		[TestCase("sqrt 1", 1, TestName = "[MathLibrary] sqrt 1")]
		[TestCase("sqrt 144", 12, TestName = "[MathLibrary] sqrt 144")]
		[TestCase("sqrt -1", -1, TestName = "[MathLibrary] sqrt -1", ExpectedException = typeof(ArgumentException))]
		static public void SqrtTest(string expression, double result)
		{
			Assert.AreEqual(MathLibrary.Compute(expression), result);
		}


		[Test]
		[Category("MathLibrary")]
		static public void NotValidCommandTest()
		{
			Assert.AreEqual(MathLibrary.Compute("test"), double.NaN);
		}
	}
}
