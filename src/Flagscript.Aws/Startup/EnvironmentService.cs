using System;

using static Flagscript.Aws.Startup.EnvironmentConstants;
using static Flagscript.Aws.Startup.EnvironmentVariableConstants;

namespace Flagscript.Aws.Startup
{

	/// <summary>
	/// Hold the environment variable outside of the asp.net core stack.
	/// </summary>
	public class EnvironmentService : IEnvironmentService
	{

		#region Properties

		/// <summary>
		/// Configured environment name.
		/// </summary>
		/// <value>Configured environment name.</value>
		public string EnvironmentName { get; set; }

		/// <summary>
		/// Whether or not the current environment is production.
		/// </summary>
		/// <value><c>true</c> if the enviornment is production, otherwise false.</value>
		public bool IsProduction => EnvironmentName.Equals(Production, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Whether or not the current environment is staging.
		/// </summary>
		/// <value><c>true</c> if the enviornment is staging, otherwise false.</value>
		public bool IsStaging => EnvironmentName.Equals(Staging, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Whether or not the current environment is qa.
		/// </summary>
		/// <value><c>true</c> if the enviornment is qa, otherwise false.</value>
		public bool IsQa => EnvironmentName.Equals(Qa, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Whether or not the current environment is development.
		/// </summary>
		/// <value><c>true</c> if the enviornment is development, otherwise false.</value>
		public bool IsDevelopment => EnvironmentName.Equals(Development, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Whether or not the current environment is unit test.
		/// </summary>
		/// <value><c>true</c> if the enviornment is unit test, otherwise false.</value>
		public bool IsUnitTest => EnvironmentName.Equals(UnitTest, StringComparison.OrdinalIgnoreCase);

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public EnvironmentService()
		{

			EnvironmentName = Environment.GetEnvironmentVariable(AspnetCoreEnvironment) ?? Production;

		}

		/// <summary>
		/// Unit testing constructor.
		/// </summary>
		/// <param name="environment">Environment to use for unit testing.</param>
		public EnvironmentService(string environment)
		{

			EnvironmentName = environment ?? throw new ArgumentNullException(nameof(environment));

		}

		#endregion

	}

}