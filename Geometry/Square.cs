using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	public class Square :Geometry.Ractangle
	{
		public Square(double side, int start_x, int start_y, int line_width, Color color)
		: base(side, side, start_x, start_y, line_width, color) { }
		public override void GetProperties()
		{
			Console.WriteLine($"Квадрат: Сторона = {width}");
		}
	}
}
