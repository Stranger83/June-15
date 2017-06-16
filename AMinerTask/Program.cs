using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
	class Program
	{
		static void Main(string[] args)
		{
			var resourcesQuantities = new Dictionary<string, decimal>();
			var input = Console.ReadLine();
			while (input != "stop")
			{
				var resource = input;
				var quantity = decimal.Parse(Console.ReadLine());

				if (!resourcesQuantities.ContainsKey(resource))
				{
					resourcesQuantities[resource] = 0;
				}
				
				resourcesQuantities[resource] += quantity;
				input = Console.ReadLine();
			}
			foreach (var pair in resourcesQuantities)
			{
				var resource = pair.Key;
				var quantity = pair.Value;
				Console.WriteLine($"{resource} -> {quantity}");
			}
		}
	}
}
