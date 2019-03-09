using System;

using Microsoft.Extensions.Configuration;
using Xunit;

using static Flagscript.Aws.Startup.EnvironmentConstants;

namespace Flagscript.Aws.Startup.Test
{

	/// <summary>
	/// Unit tests for <see cref="ConfigurationService"/>.
	/// </summary>
	public class ConfigurationServiceTest
	{

		#region TestMethods

		/// <summary>
		/// Ensures service contracts <see cref="IConfigurationService"/>.
		/// </summary>
		[Fact]
		public void TestInterface()
		{

			ConfigurationService configurationService = new ConfigurationService();
			Assert.IsAssignableFrom<IConfigurationService>(configurationService);

		}

		/// <summary>
		/// Tests <see cref="ConfigurationService"/> defaults to the production 
		/// asp.net environment.
		/// </summary>
		[Fact]
		public void TestDefaultConstructorEnvironment()
		{

			ConfigurationService configurationService = new ConfigurationService();
			Assert.Equal(Production, configurationService.EnvironmentService.EnvironmentName);
		}

		/// <summary>
		/// Tests <see cref="ConfigurationService(IEnvironmentService)"/> on 
		/// null environment service.
		/// </summary>
		[Fact]
		public void TestConstructorNullEnvironment()
		{

			try
			{
				ConfigurationService configurationService = new ConfigurationService(null);
				Assert.True(false);
			}
			catch (ArgumentNullException ae)
			{
				Assert.Equal("environmentService", ae.ParamName);
			}

		}

		/// <summary>
		/// Tests <see cref="ConfigurationService(IEnvironmentService)"/> defaults 
		/// to the specified environemtn.
		/// </summary>
		[Fact]
		public void TestConstructorSpecificEnvironment()
		{
			string myEnv = "FlagscriptEnvironment";
			IEnvironmentService environmentService = new EnvironmentService(myEnv);
			ConfigurationService configurationService = new ConfigurationService(environmentService);
			Assert.Equal(myEnv, configurationService.EnvironmentService.EnvironmentName);
		}

		/// <summary>
		/// Tests that the root appsettings is loaded on an unspecified environment.
		/// </summary>
		[Fact]
		public void TestRootJsonLoad()
		{
		
			ConfigurationService configurationService 
				= new ConfigurationService(new EnvironmentService("FlagscriptEnvironment"));
			IConfiguration rootConfig = configurationService.GetConfiguration();
			string configValue = rootConfig.GetSection("Flagscript").GetSection("ConfigEnv").Value;
			Assert.Equal("Production", configValue);

		}

		/// <summary>
		/// Tests that an alternate appsettings is loaded on an specified environment.
		/// </summary>
		[Fact]
		public void TestAlternateEnvironmentJsonLoad()
		{

			ConfigurationService configurationService
				= new ConfigurationService(new EnvironmentService("UnitTest"));
			IConfiguration rootConfig = configurationService.GetConfiguration();
			string configValue = rootConfig.GetSection("Flagscript").GetSection("ConfigEnv").Value;
			Assert.Equal("UnitTest", configValue);

		}

		/// <summary>
		/// Test that the environment variables are loaded into config.
		/// </summary>
		[Fact]
		public void TestEnvironmentVariableLoad()
		{

			Environment.SetEnvironmentVariable("Foo", "Bar");
			ConfigurationService configurationService
				= new ConfigurationService(new EnvironmentService("FlagscriptEnvironment"));
			IConfiguration rootConfig = configurationService.GetConfiguration();
			Assert.Equal("Bar", rootConfig.GetSection("Foo").Value);
			
		}

		#endregion

	}

}
