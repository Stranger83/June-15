using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
	class Program
	{
		static void Main(string[] args)
		{

			var keyMaterials = new Dictionary<string, int>();
			keyMaterials["shards"] = 0;
			keyMaterials["fragments"] = 0;
			keyMaterials["motes"] = 0;
			var junk = new SortedDictionary<string, int>();
			bool readRes = true;
			while (readRes)
			{
				string[] input = Console.ReadLine().ToLower().Split().ToArray();

				for (int i = 0; i < input.Length; i+=2)
				{
					var value = int.Parse(input[i]);
					var resource = input[i + 1];
					if (keyMaterials.ContainsKey(resource))
					{
						keyMaterials[resource] += value;

						if (keyMaterials["shards"] >= 250)
						{
							keyMaterials["shards"] -= 250;
							Console.WriteLine("Shadowmourne obtained!");
							readRes = false;
							break;
						}
						if (keyMaterials["fragments"] >= 250)

						{
							keyMaterials["fragments"] -= 250;
							Console.WriteLine("Valanyr obtained!");
							readRes = false;
							break;
						}
						if (keyMaterials["motes"] >= 250)
						{
							keyMaterials["motes"] -= 250;
							Console.WriteLine("Dragonwrath obtained!");
							readRes = false;
							break;
						}

					}
					else
					{
						if (!junk.ContainsKey(resource))
						{
							junk[resource] = 0;
						}
						junk[resource] += value;
					}
				}
			}
			var orderedKeyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
			foreach (var kvp in orderedKeyMaterials)
			{
				var material = kvp.Key;
				var value = kvp.Value;
				Console.WriteLine($"{material}: {value}");
			}
			foreach (var kvp in junk)
			{
				var material = kvp.Key;
				var value = kvp.Value;
				Console.WriteLine($"{material}: {value}");
			}
		}
	}
}
