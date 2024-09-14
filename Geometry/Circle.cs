using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	public class Circle:Shape
	{
		double radius;
		public double Radius
		{
			get => radius;
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				radius = value;
			}
		}
		public Circle(double radius, int start_x, int start_y, int line_width, Color color)
		: base(start_x, start_y, line_width, color)
		{
			Radius = radius;
		}

		public override double GetArea()
		{
			return Math.PI* Radius*Radius;
		}
		public override double GetPerimeter()
		{
			return 2*Math.PI*Radius;
		}
		public override void GetProperties()
		{
			Console.WriteLine($"Круг: Радиус = {Radius}");
		}
		public override void Draw(PaintEventArgs e)
		{
			using (Pen pen = new Pen(Color, LineWidth))
			{
				e.Graphics.DrawEllipse(pen, StartX, StartY, (int)Radius * 2, (int)Radius * 2);
			}
		}
	}
}
