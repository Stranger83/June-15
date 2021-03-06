﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
	class Program
	{
		static void Main(string[] args)
		{
			var phonebook = new Dictionary<string, string>();

			while (true)
			{
				var command = Console.ReadLine().Split().ToArray();
				if (command[0] == "END")
				{
					break;
				}
				if (command[0] == "A")
				{
					if (phonebook.ContainsKey(command[1]))
					{
						phonebook[command[1]] = command[2];
					}
					else
					{
						phonebook.Add(command[1], command[2]);
					}
				}
				else
				{

					if (phonebook.ContainsKey(command[1]))
					{
						foreach (var item in phonebook)
						{
							if (item.Key.Equals(command[1]))
							{
								Console.WriteLine($"{item.Key} -> {item.Value}");
							}
						}
					}
					else
					{
						Console.WriteLine($"Contact {command[1]} does not exist.");
					}
				}
			}
		}
	}
}
