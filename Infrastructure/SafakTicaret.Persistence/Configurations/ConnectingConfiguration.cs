using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafakTicaret.Persistence.Configurations
{
	static class ConnectingConfiguration
	{
        public static string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Precentation/SafakTicaret.API")).AddJsonFile("appsettings.json");
				return configurationManager.GetConnectionString("MSSql");
			}
		}
    }
}
