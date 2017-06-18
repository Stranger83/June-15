using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			var typeNameStats = new Dictionary<string, SortedDictionary<string, Dictionary<string, int>>>();
			for (int i = 0; i < n; i++)
			{
				var input = Console.ReadLine().Split();
				var type = input[0];
				var name = input[1];
				int damage;
				var isDamageValid = int.TryParse(input[2], out damage);
				int health;
				var isHealthValid = int.TryParse(input[3], out health);
				int armor;
				var isArmorValid = int.TryParse(input[4], out armor);
				if (input[3] == "null")
				{
					health = 250;
				}
				if (input[2] == "null")
				{
					damage = 45;
				}
				if (input[4] == "null")
				{
					armor = 10;
				}

				if (!typeNameStats.ContainsKey(type))
				{
					typeNameStats[type] = new SortedDictionary<string, Dictionary<string, int>>();
				}
				if (!typeNameStats[type].ContainsKey(name))
				{
					typeNameStats[type][name] = new Dictionary<string, int>();
					typeNameStats[type][name].Add("damage", 0);
					typeNameStats[type][name].Add("health", 0);
					typeNameStats[type][name].Add("armor", 0);
				}
				typeNameStats[type][name]["damage"] = damage;
				typeNameStats[type][name]["health"] = health;
				typeNameStats[type][name]["armor"] = armor;

			}
			
			foreach (var item in typeNameStats)
			{
				var str = "";
				var totalHealth = 0.0;
				var totalDmg = 0.0;
				var totalArmor = 0.0;
				var type = item.Key;
				var nameStats = item.Value;
				foreach (var kvp in nameStats)
				{
					var name = kvp.Key;
					var stats = kvp.Value;
					str += $"-{name} -> ";
					foreach (var stat in stats)
					{
						var statistic = stat.Key;
						var val = stat.Value;
						switch (statistic)
						{
							case "health":
								totalHealth += val;
								break;
							case "armor":
								totalArmor += val;
								break;
							case "damage":
								totalDmg += val;
								break;
						}
						str += $"{statistic}: {val}" + (statistic.Equals(stats.Last().Key) ? "\n" : ", ");
					}
				}
				Console.WriteLine($"{type}::({totalDmg/nameStats.Count:f2}/{totalHealth / nameStats.Count:f2}/{totalArmor / nameStats.Count:f2})");
				Console.Write(str);
			}
		}
	}
}
