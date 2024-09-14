using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
	internal class Program
	{
		
		[DllImport("kernel32.dll")]	// Получение окна консоли
		public static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll", SetLastError = true)]  // Получение контекста устройства для рисования
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]    // Освобождение контекста устройства
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			IntPtr hdc = GetDC(hwnd);
			int consoleWidth = Console.WindowWidth * 20;
			int consoleHeight = Console.WindowHeight * 25;
			using (Graphics graphics = Graphics.FromHdc(hdc))
			{
				//Rectangle rect = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
				Rectangle rect = new Rectangle(0, 0, consoleWidth, consoleHeight);
				PaintEventArgs e = new PaintEventArgs(graphics, rect);
				List<Shape> shapes = new List<Shape>();
				Random rand = new Random();
				for (int i = 0; i < 5; i++)
				{
					int shapeType = rand.Next(4);
					switch (shapeType)
					{
						case 0:
							shapes.Add(new Square(rand.Next(50, 200), rand.Next(100, 500), rand.Next(100, 500), rand.Next(1, 5), Color.Blue));
							break;
						case 1:
							shapes.Add(new Ractangle(rand.Next(50, 200), rand.Next(50, 200), rand.Next(100, 500), rand.Next(100, 500), rand.Next(1, 5), Color.Red));
							break;
						case 2:
							shapes.Add(new Circle(rand.Next(50, 100), rand.Next(100, 500), rand.Next(100, 500), rand.Next(1, 5), Color.Green));
							break;
						case 3:
							shapes.Add(new Triangle(rand.Next(50, 200), rand.Next(50, 200), rand.Next(50, 200), rand.Next(100, 500), rand.Next(100, 500), rand.Next(1, 5), Color.Purple));
							break;
					}
				}
				Console.Clear();
				foreach (Shape shape in shapes)
				{
					shape.GetProperties();
					Console.WriteLine($"Площадь: {shape.GetArea()}");
					Console.WriteLine($"Периметр: {shape.GetPerimeter()}");
					shape.Draw(e);
					Console.WriteLine();
				}
			}
			if (hdc != IntPtr.Zero)
			{
				ReleaseDC(hwnd, hdc);
			}
		}
	}
}
