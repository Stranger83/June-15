using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
	class Program
	{
		static void Main(string[] args)
		{
			var namesEmails = new Dictionary<string, string>();
			var input = Console.ReadLine();
			while (input != "stop")
			{
				var name = input;
				var email = Console.ReadLine();

				namesEmails[name] = email;
				
				input = Console.ReadLine();
			}
			var fixedEmails = namesEmails
				.Where(kvp => !(kvp.Value.EndsWith("us") || kvp.Value.EndsWith("uk")))
				.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

			foreach (var kvp in fixedEmails)
			{
				var name = kvp.Key;
				var email = kvp.Value;
				Console.WriteLine($"{name} -> {email}");
			}
		}
	}
}
