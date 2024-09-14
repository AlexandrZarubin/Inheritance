using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_201_ready
{
	abstract class FileInterface
	{
		protected string FileName;

		protected FileInterface(string fileName)
		{
			FileName = fileName;
		}

		public void Process()
		{
			if (OpenFile())
			{
				Do();
				CloseFile();
			}
			else
			{
				Console.WriteLine($"Ошибка при открытии файла: {FileName}");
			}
		}

		protected abstract bool OpenFile();
		protected abstract void CloseFile();
		protected abstract void Do();
	}

	class Reader : FileInterface
	{
		private StreamReader inputFile;
		private List<string> str = new List<string>();

		public Reader(string inputFileName) : base(inputFileName) { }

		public List<string> GetLines()
		{
			return str;
		}

		protected override bool OpenFile()
		{
			try
			{
				inputFile = new StreamReader(FileName);
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected override void CloseFile()
		{
			inputFile?.Close();
		}

		protected override void Do()
		{
			string Buffer;
			while ((Buffer = inputFile.ReadLine()) != null)
			{
				if (!string.IsNullOrWhiteSpace(Buffer))
				{
					str.Add(Buffer);
				}
			}
		}
	}

	class Writer : FileInterface
	{
		private StreamWriter outputFile;
		private List<string> str;

		public Writer(string outputFileName, List<string> Temp) : base(outputFileName)
		{
			this.str = Temp;
		}

		protected override bool OpenFile()
		{
			try
			{
				this.outputFile = new StreamWriter(FileName);
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected override void CloseFile()
		{
			this.outputFile?.Close();
		}

		protected override void Do()
		{
			foreach (string item in this.str)
			{
				string[] parts = item.Split(new[] { ' ' }, 2);
				if (parts.Length == 2)
				{
					string ip = parts[0];
					string mac = parts[1].Trim();
					this.outputFile.Write(mac);
					this.outputFile.Write(new string(' ', CountSpaces(item)));
					this.outputFile.Write(ip);
					this.outputFile.WriteLine();
				}
			}
		}

		private int CountSpaces(string line)
		{
			int count = 0;
			foreach (char c in line)
			{
				if (c == ' ')
				{
					count++;
				}
			}
			return count;
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Reader reader = new Reader("201 RAW.txt");
			reader.Process();

			List<string> Temp = reader.GetLines();

			foreach (var line in Temp)
			{
				Console.WriteLine(line);
			}

			Writer writer = new Writer("201 ready.txt", Temp);
			writer.Process();
			System.Diagnostics.Process.Start("notepad", "201 ready.txt");
		}
	}
}
