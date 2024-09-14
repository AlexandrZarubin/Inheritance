using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Geometry
{
	abstract public class Shape
	{
		int start_x;
		int start_y;
		int line_width;
		public const int MIN_START_X = 400;
		public const int MIN_START_Y = 200;
		public const int MAX_START_X = 800;
		public const int MAX_START_Y = 300;

		public const int MIN_LINE_WIDTH = 3;
		public const int MAX_LINE_WIDTH = 33;

		public const int MIN_SIZE = 50;
		public const int MAX_SIZE = 550;
		public Color Color { get; set; }
		public int StartX
		{
			get { return start_x; }
			set 
			{
				if (value < MIN_START_X) value = MIN_START_X;
				if (value > MAX_START_X) value = MAX_START_X;
				start_x = value;
			}
		}
		public int StartY
		{
			get { return start_y; } 
			set
			{
				if (value < MIN_START_Y) value = MIN_START_Y;
				if (value > MAX_START_Y) value = MAX_START_Y;
				start_y = value;
			}
		}
		public int LineWidth
		{
			get { return line_width; }
			set
			{
				if (line_width < MIN_LINE_WIDTH) line_width = MIN_LINE_WIDTH;
				if (line_width > MAX_LINE_WIDTH) line_width = MAX_LINE_WIDTH;
				line_width = value;
			}
		}
		public Shape(int start_x, int start_y, int line_width, Color color)
		{
			StartX = start_x;
			StartY = start_y;
			LineWidth = line_width;
			Color = color;
		}
		public abstract double GetArea(); // Абстрактный метод для вычисления площади
		public abstract double GetPerimeter(); // Абстрактный метод для вычисления периметра
		public abstract void GetProperties(); // Абстрактный метод для вывода основных свойств фигуры
		public abstract void Draw(PaintEventArgs e); // Абстрактный метод для рисования фигуры
	}
}
