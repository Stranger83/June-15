using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srpsko
{
	class Program
	{
		static void Main(string[] args)
		{

			var input = Console.ReadLine();
			var venueSingerProfit = new Dictionary<string, Dictionary<string, long>>();
			while (input != "End")
			{
				try
				{
					int index = input.IndexOf(" @");
					string singer = input.Substring(0, index);
					var venuePriceTickets = input.Substring(index + 2).Split().ToList();
					int ticketsSold = int.Parse(venuePriceTickets.Last());
					venuePriceTickets.RemoveAt(venuePriceTickets.Count - 1);
					int ticketPrice = int.Parse(venuePriceTickets.Last());
					venuePriceTickets.RemoveAt(venuePriceTickets.Count - 1);
					long profit = ticketsSold * ticketPrice;
					string venue = string.Join(" ", venuePriceTickets);

					if (!venueSingerProfit.ContainsKey(venue))
					{
						venueSingerProfit[venue] = new Dictionary<string, long>();
					}
					if (!venueSingerProfit[venue].ContainsKey(singer))
					{
						venueSingerProfit[venue][singer] = 0;
					}
					venueSingerProfit[venue][singer] += profit;
				}
				catch
				{
				}
				
				input = Console.ReadLine();
			}
			
			foreach (var item in venueSingerProfit)
			{
				var venue = item.Key;
				var singerProfit = item.Value;
				Console.WriteLine(venue);
				var ordered = singerProfit.OrderByDescending(x => x.Value);

				foreach (var kvp in ordered)
				{
					Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");

				}
			}
		}
	}
}
