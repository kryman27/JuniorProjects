using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
	public class WeatherData
	{
		public DailyData hourly { get; set; }
	}

	public class DailyData
	{
		public List<string> time { get; set; }
		public List<double> temperature_2m { get; set; }
	}
}
