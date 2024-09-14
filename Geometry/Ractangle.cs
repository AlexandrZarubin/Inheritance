using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	public class Ractangle : Shape
	{
		double _width;
		double _height;
		public double width
		{
			get { return _width; }
			set 
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				_width = value;
			}
		}
		public double height
		{
			get => _height;
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				_height = value;
			}
		}
		public Ractangle(double side_a, double side_b, int start_x, int start_y, int line_width, Color color)
		: base(start_x, start_y, line_width, color)
		{
			width = side_a;
			height = side_b;
		}

		public override double GetArea()//площади прямоугольник
		{
			return width * height;
		}

		public override double GetPerimeter()//периметра прямоугольника
		{
			return 2*(width+height);
		}
		public override void GetProperties()
		{
			Console.WriteLine($"Прямоугольник: Сторона A = {width}, Сторона B = {height}");
		}

		public override void Draw(PaintEventArgs e)
		{
			using (Pen pen = new Pen(Color, LineWidth))
			{
				e.Graphics.DrawRectangle(pen, StartX, StartY, (int)width, (int)height);
			}
		}

	}
}
