using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCS_201_dscpd
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string inputFileName = "201 RAW.txt";
			string outputFileName = "201.dhcpd.txt";
			using (StreamReader reader = new StreamReader(inputFileName))
			using (StreamWriter writer = new StreamWriter(outputFileName))
			{
				string Str;
				int hostCount = 1;
				while ((Str = reader.ReadLine()) != null)
				{
					string[] parts = Str.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (parts.Length == 2)
					{
						string ip = parts[0];
						string mac = parts[1].Replace('-', ':');

						writer.WriteLine($"host-{hostCount}");
						writer.WriteLine("{");
						writer.WriteLine($"\thardware ethernet\t{mac};");
						writer.WriteLine($"\tfixed-address\t\t{ip};");
						writer.WriteLine("}");
						writer.WriteLine();
						hostCount++;
					}
				}
			}
			System.Diagnostics.Process.Start("notepad", "201.dhcpd.txt");

		}
	}
}
