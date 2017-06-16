using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			var namesIPsDuration = new SortedDictionary<string, SortedDictionary<string, int>>();
			for (int i = 0; i < n; i++)
			{
				var input = Console.ReadLine();
				var tokens = input.Split();
				var name = tokens[1];
				var ip = tokens[0];
				var duration = int.Parse(tokens[2]);

				if (!namesIPsDuration.ContainsKey(name))
				{
					namesIPsDuration[name] = new SortedDictionary<string, int>();
				}
				if (!namesIPsDuration[name].ContainsKey(ip))
				{
					namesIPsDuration[name][ip] = 0;
				}
				namesIPsDuration[name][ip] += duration;
			}
			foreach (var kpv in namesIPsDuration)
			{
				var name = kpv.Key;
				var ipsDurations = kpv.Value;

				var totalDuration = ipsDurations.Sum(a => a.Value);
				var ips = ipsDurations.Keys.ToArray();

				Console.WriteLine($"{name}: {totalDuration} [{string.Join(", ", ips)}]");

			}
		}
	}
}
