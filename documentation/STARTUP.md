# Non ASP.NET Startup (>= v1.0.0)  

Certain AWS constructs are not able to boot with ASP.NET Core DI and Configuration (e.g. Direct Alexa Lambda Functions). The Flagscript.Aws package provides a mechanism to bootstrap standard appsettings files when not in an ASP.NET Core environment.

## Using the modified bootstrap

The startup classes are in the namespace Flagscript.Aws.Startup.   

```csharp
using Flagscript.Aws.Startup
```  

## Choosing the Environment. 

The interface **_IEnvironmentService_** provides access to the environment which the current application is running in.  

A default implementation - **_EnvironmentService_** is provided to allow automatic or manual selection of the environment. This implementation provides two constructors. 

```csharp
// Default Constructor.
IEnvironmentService environmentService = new EnvironmentService();
string environment = environmentService.EnvironmentName;
// environment will be set to the value of the environment variable ASPNETCORE_ENVIRONMENT, 
// or will default to 'Production' if the variable is not set. 

// Selection Constructor
IEnvironmentService environmentService = new EnvironmentService("Staging");
string environment = environmentService.EnvironmentName;
// environment is 'Staging'
```

## Getting the configuration  

The interface IConfigurationSerice provides access to a standard load of the environments IConfiguration.  

A default implementation **_ConfigurationService_** is provided to load configuration in the typical manner. This service will load appsettings.json, appsettings.{Environment}.json, as well as the environment variables. 

The following appsettings.json:   

```json
{
  "VarOne": "ValOne",
  "VarTwo": "ValTwo"
}
```.   

and the follwing appsettings.Staging.json:   

```json
{
  "VarOne": "Flagscript"
}
```

along with the Environment Variable 'Foo' with value 'Bar' will yield the following from the configuration service. 

```csharp
IEnvironmentService environmentService = new EnvironmentService("Staging");
IConfigurationService configurationService = new ConfigurationService(environmentService);
IConfiguration config = configurationService.GetConfiguration();

// Value is 'Flagscript'
string varOne = config.GetSection("VarOne").Value;

// Value is 'ValTwo'
string varTwo = config.GetSection("VarTwo").Value;

// Value is 'Bar'
string barEnv = config.GetSection("Foo").Value;

```
