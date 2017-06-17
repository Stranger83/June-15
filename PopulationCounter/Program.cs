using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			var countryCityPopulation = new Dictionary<string, Dictionary<string, decimal>>();
			while(input != "report")
			{
				var tokens = input.Split('|');
				var country = tokens[1];
				var city = tokens[0];
				var population = decimal.Parse(tokens[2]);

				if (!countryCityPopulation.ContainsKey(country))
				{
					countryCityPopulation[country] = new Dictionary<string, decimal>();
				}
				if (!countryCityPopulation[country].ContainsKey(city))
				{
					countryCityPopulation[country][city] = 0;
				}
				countryCityPopulation[country][city] += population;
				
				input = Console.ReadLine();
			}

			var tempDict = new Dictionary<string, decimal>();
			foreach (var kvp in countryCityPopulation)
			{
				var country = kvp.Key;
				var citiesPop = kvp.Value;
				var totalPop = citiesPop.Sum(x => x.Value);
				tempDict[country] = totalPop;
			}
			var orderedCountries = tempDict.OrderByDescending(x => x.Value);

			foreach (var kvp in orderedCountries)
			{
				var country = kvp.Key;
				var totalPop = kvp.Value;
				Console.WriteLine($"{country} (total population: {totalPop})");
				var orderedCities = countryCityPopulation[country].OrderByDescending(x => x.Value);
				foreach (var city in orderedCities)
				{
					var cities = city.Key;
					var pop = city.Value;
									
					Console.WriteLine($"=>{cities}: {pop}");
				}
			}
		}
	}
}
