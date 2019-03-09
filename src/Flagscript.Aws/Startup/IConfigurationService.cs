using Microsoft.Extensions.Configuration;

namespace Flagscript.Aws.Startup
{

	/// <summary>
	/// Interface to hold the configuration stack outside of the asp.net core stack.
	/// </summary>
	public interface IConfigurationService
	{

		/// <summary>
		/// The system configuration.
		/// </summary>
		/// <value>The system configuration.</value>
		IConfiguration GetConfiguration();

	}

}