/*
 * Тесты для исполняемой сборки
 * 
 * Сергей Григорьев, для ByndyuSoft`s Summer School
 * 2013-06-04
*/


using TestTask.Executable;
using NUnit.Framework;
using System;
using System.Reflection;


namespace TestTask.UnitTests
{
	[TestFixture]
	class ExecutableUnitTests
	{
		static Program program = new Program();

		public ExecutableUnitTests()
		{
			program.LoadPlugins();
			program.SelectPlugin(0);
		}


		[Test]
		[Category("Executable")]
		static public void LoadPluginTest()
		{
			Program prog = new Program();
			Assert.AreEqual(prog.LoadPlugins(), 1);
		}


		[Test]
		[Category("Executable")]
		static public void SelectPluginTest()
		{
			Assert.AreEqual(program.SelectPlugin(0), true);
		}


		[Test]
		[Category("Executable")]		
		[TestCase("summ 2 3", 5, TestName = "[Executable] summ 2 3")]
		[TestCase("summ 22,2 11,1", 33.3, TestName = "[Executable] summ 22,2 11,1")]
		static public void SummTest(string expression, double result)
		{			
			Assert.AreEqual(program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]		
		[TestCase("difference 5 3", 2, TestName = "[Executable] difference 5 3")]
		[TestCase("difference 22,2 11,1", 11.1, TestName = "[Executable] difference 22,2 11,1")]
		static public void DifferenceTest(string expression, double result)
		{
			Assert.AreEqual(program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]		
		[TestCase("multiplication 5 3", 15, TestName = "[Executable] multiplication 5 3")]
		[TestCase("multiplication 0,2 0,3", 0.06, TestName = "[Executable] multiplication 0,2 0,3")]
		static public void MultiplicationTest(string expression, double result)
		{
			Assert.AreEqual(program.Compute(expression), result);
		}

		
		[Test]
		[Category("Executable")]		
		[TestCase("division 15 3", 5, TestName = "[Executable] division 15 3")]
		[TestCase("division 0,06 0,3", 0.2, TestName = "[Executable] division 0,06 0,3")]
		[TestCase("division 15 0", 0, TestName = "[Executable] division 15 0", ExpectedException = typeof(TargetInvocationException))]
		static public void DivisionTest(string expression, double result)
		{
			Assert.AreEqual(program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]		
		[TestCase("factorial 1", 1, TestName = "[Executable] factorial 1")]
		[TestCase("factorial 5", 120, TestName = "[Executable] factorial 5")]
		static public void FactorialTest(string expression, double result)
		{
			Assert.AreEqual(program.Compute(expression), result);
		}


		[Test]
		[Category("Executable")]		
		[TestCase("sqrt 1", 1, TestName = "[Executable] sqrt 1")]
		[TestCase("sqrt 144", 12, TestName = "[Executable] sqrt 144")]
		[TestCase("sqrt -1", -1, TestName = "[Executable] sqrt -1", ExpectedException = typeof(TargetInvocationException))]
		static public void SqrtTest(string expression, double result)
		{
			Assert.AreEqual(program.Compute(expression), result);
		}
	}
}
