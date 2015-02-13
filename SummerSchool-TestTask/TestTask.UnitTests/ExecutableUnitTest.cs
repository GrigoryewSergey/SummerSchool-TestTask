namespace TestTask.UnitTests
{
	using System.Reflection;
	using Executable;
	using NUnit.Framework;

	[TestFixture]
	class ExecutableUnitTests
	{
		private static readonly Calculator Program = new Calculator();

		public ExecutableUnitTests()
		{
			Program.LoadPlugins();
			Program.SelectPlugin(0);
		}


		[Test]
		[Category("Executable")]
		[TestCase("difference 5 3", 2, TestName = "[Executable] difference 5 3")]
		[TestCase("difference 22.2 11.1", 11.1, TestName = "[Executable] difference 22,2 11,1")]
		public static void DifferenceTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]
		[TestCase("division 15 3", 5, TestName = "[Executable] division 15 3")]
		[TestCase("division 0.06 0.3", 0.2, TestName = "[Executable] division 0,06 0,3")]
		[TestCase("division 15 0", 0, TestName = "[Executable] division 15 0",
			ExpectedException = typeof (TargetInvocationException))]
		public static void DivisionTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]
		[TestCase("factorial 1", 1, TestName = "[Executable] factorial 1")]
		[TestCase("factorial 5", 120, TestName = "[Executable] factorial 5")]
		public static void FactorialTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}

		[Test]
		[Category("Executable")]
		public static void LoadPluginTest()
		{
			var prog = new Calculator();
			Assert.AreEqual(prog.LoadPlugins(), 1);
		}

		[Test]
		[Category("Executable")]
		[TestCase("multiplication 5 3", 15, TestName = "[Executable] multiplication 5 3")]
		[TestCase("multiplication 0.2 0.3", 0.06, TestName = "[Executable] multiplication 0,2 0,3")]
		public static void MultiplicationTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}

		[Test]
		[Category("Executable")]
		public static void SelectPluginTest()
		{
			Assert.AreEqual(Program.SelectPlugin(0), true);
		}


		[Test]
		[Category("Executable")]
		[TestCase("sqrt 1", 1, TestName = "[Executable] sqrt 1")]
		[TestCase("sqrt 144", 12, TestName = "[Executable] sqrt 144")]
		[TestCase("sqrt -1", -1, TestName = "[Executable] sqrt -1", ExpectedException = typeof (TargetInvocationException))]
		public static void SqrtTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}

		[Test]
		[Category("Executable")]
		[TestCase("summ 2 3", 5, TestName = "[Executable] summ 2 3")]
		[TestCase("summ 22.2 11.1", 33.3, TestName = "[Executable] summ 22,2 11,1")]
		public static void SummTest(string expression, double result)
		{
			Assert.AreEqual(Program.Compute(expression), result);
		}
	}
}