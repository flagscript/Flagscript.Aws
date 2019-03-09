using System;

using Xunit;

using static Flagscript.Aws.Startup.EnvironmentConstants;

namespace Flagscript.Aws.Startup.Test
{

	/// <summary>
	/// Unit Tests for <see cref="EnvironmentService"/>.
	/// </summary>
	public class EnvironmentServiceTest
	{

		#region Test Methods

		/// <summary>
		/// Ensures service contracts <see cref="IEnvironmentService"/>.
		/// </summary>
		[Fact]
		public void TestInterface()
		{

			EnvironmentService environmentService = new EnvironmentService();
			Assert.IsAssignableFrom<IEnvironmentService>(environmentService);

		}

		/// <summary>
		/// Tests <see cref="EnvironmentService"/> defaults to the production 
		/// asp.net environment.
		/// </summary>
		[Fact]
		public void TestDefaultConstructorEnvironment()
		{

			EnvironmentService environmentService = new EnvironmentService();
			Assert.Equal(Production, environmentService.EnvironmentName);

		}

		/// <summary>
		/// Tests <see cref="EnvironmentService(string)"/> on null environment.
		/// </summary>
		[Fact]
		public void TestNamedConstructorNull()
		{
		
			try
			{
				EnvironmentService environmentService = new EnvironmentService(null);
				Assert.True(false);
			}
			catch (ArgumentNullException ae)
			{
				Assert.Equal("environment", ae.ParamName);
			}

		}

		/// <summary>
		/// Tests <see cref="EnvironmentService(string)"/> sets non-standard value.
		/// </summary>
		[Fact]
		public void TestNamedConstructorValue()
		{

			string flagEnv = "FlagscriptEnvironment";
			EnvironmentService environmentService = new EnvironmentService(flagEnv);
			Assert.Equal(flagEnv, environmentService.EnvironmentName);

		}

		/// <summary>
		/// Tests the <see cref="EnvironmentService.IsProduction"/> setting.
		/// </summary>
		[Fact]
		public void TestIsProduction()
		{

			EnvironmentService environmentService = new EnvironmentService("proDucTion");
			Assert.True(environmentService.IsProduction);

			environmentService = new EnvironmentService("prod");
			Assert.False(environmentService.IsProduction);

		}

		/// <summary>
		/// Tests the <see cref="EnvironmentService.IsStaging"/> setting.
		/// </summary>
		[Fact]
		public void TestIsStaging()
		{

			EnvironmentService environmentService = new EnvironmentService("sTaGiNG");
			Assert.True(environmentService.IsStaging);

			environmentService = new EnvironmentService("stg");
			Assert.False(environmentService.IsStaging);

		}

		/// <summary>
		/// Tests the <see cref="EnvironmentService.IsQa"/> setting.
		/// </summary>
		[Fact]
		public void TestIsQa()
		{

			EnvironmentService environmentService = new EnvironmentService("qA");
			Assert.True(environmentService.IsQa);

			environmentService = new EnvironmentService("myQ");
			Assert.False(environmentService.IsQa);

		}

		/// <summary>
		/// Tests the <see cref="EnvironmentService.IsDevelopment"/> setting.
		/// </summary>
		[Fact]
		public void TestIsDevelopment()
		{

			EnvironmentService environmentService = new EnvironmentService("deVelOpmEnt");
			Assert.True(environmentService.IsDevelopment);

			environmentService = new EnvironmentService("dev");
			Assert.False(environmentService.IsDevelopment);

		}

		/// <summary>
		/// Tests the <see cref="EnvironmentService.IsUnitTest"/> setting.
		/// </summary>
		[Fact]
		public void TestIsUnitTest()
		{

			EnvironmentService environmentService = new EnvironmentService("uNItTEsT");
			Assert.True(environmentService.IsUnitTest);

			environmentService = new EnvironmentService("testing");
			Assert.False(environmentService.IsUnitTest);

		}

		#endregion

	}

}
