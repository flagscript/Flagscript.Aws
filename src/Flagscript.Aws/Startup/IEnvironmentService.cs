namespace Flagscript.Aws.Startup
{

	/// <summary>
	/// Interface to hold the environment variable outside of the asp.net core stack.
	/// </summary>
	public interface IEnvironmentService
	{

		/// <summary>
		/// Configured environment name.
		/// </summary>
		/// <value>Configured environment name.</value>
		string EnvironmentName { get; }

		/// <summary>
		/// Whether or not the current environment is production.
		/// </summary>
		/// <value><c>true</c> if the enviornment is production, otherwise false.</value>
		bool IsProduction { get; }

		/// <summary>
		/// Whether or not the current environment is staging.
		/// </summary>
		/// <value><c>true</c> if the enviornment is staging, otherwise false.</value>
		bool IsStaging { get; }

		/// <summary>
		/// Whether or not the current environment is qa.
		/// </summary>
		/// <value><c>true</c> if the enviornment is qa, otherwise false.</value>
		bool IsQa { get; }

		/// <summary>
		/// Whether or not the current environment is development.
		/// </summary>
		/// <value><c>true</c> if the enviornment is development, otherwise false.</value>
		bool IsDevelopment { get; }

		/// <summary>
		/// Whether or not the current environment is unit test.
		/// </summary>
		/// <value><c>true</c> if the enviornment is unit test, otherwise false.</value>
		bool IsUnitTest { get; }

	}

}