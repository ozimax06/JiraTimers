using System;
using JiraTimers.Settings;
using Microsoft.Extensions.Configuration;
using Simplify.DI;

namespace JiraTimers.Setup
{
	public static class ConfigurationRegistrations
	{
		public static IDIRegistrator RegisterConfiguration(this IDIRegistrator registrator, Action<IConfiguration> config = null)
		{
			var configurationBuilder = new ConfigurationBuilder();
			var configuration = configurationBuilder.Add(new JiraTimersConfigurationSource()).Build();

			registrator.Register<IConfiguration>(p => configuration, LifetimeType.Singleton);

			config?.Invoke(configuration);

			return registrator;
		}
	}
}