using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			var userIPMsg = new SortedDictionary<string, Dictionary<string, int>>(); 
			while (input != "end")
			{
				var tokens = input.Split();
				var user = tokens[2].Split('=').Last();
				var ips = tokens[0].Split('=').Last();

				if (!userIPMsg.ContainsKey(user))
				{
					userIPMsg[user] = new Dictionary<string, int>();
				}
				if (!userIPMsg[user].ContainsKey(ips))
				{
					userIPMsg[user][ips] = 0;
				}
				userIPMsg[user][ips]++;

				input = Console.ReadLine();
			}
			foreach (var kvp in userIPMsg)
			{
				var user = kvp.Key;
				Console.WriteLine($"{user}: ");
				foreach (var item in userIPMsg[user])
				{
					var ip = item.Key;
					var msgs = item.Value;
					Console.Write($"{ip} => {msgs}" 
						+ (ip.Equals(userIPMsg[user].Last().Key) ? "." : ", "));
				}
				Console.WriteLine();
			}
		}
	}
}
