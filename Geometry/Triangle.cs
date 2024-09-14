using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	public class Triangle:Shape
	{
		double side_a;
		double side_b;
		double side_c;
		public double SideA
		{
			get => side_a;
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				side_a = value;
			}
		}
		public double SideB
		{
			get => side_b;
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				side_b = value;
			}
		}
		public double SideC
		{
			get => side_c;
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				side_c = value;
			}
		}
		public Triangle(double side_a, double side_b, double side_c, int start_x, int start_y, int line_width, Color color)
		: base(start_x, start_y, line_width, color)
		{
			SideA = side_a;
			SideB = side_b;
			SideC = side_c;
		}
		public override double GetArea()
		{
			double s = (SideA+SideB+SideC)/2;
			return Math.Sqrt(s*(s - SideA) * (s - SideB) * (s - SideC));
		}
		public override double GetPerimeter()
		{
			return SideA + SideB + SideC;
		}
		public override void GetProperties()
		{
			Console.WriteLine($"Треугольник: Стороны A = {SideA}, B = {SideB}, C = {SideC}");
		}
		public override void Draw(PaintEventArgs e)
		{
			using (Pen pen = new Pen(Color, LineWidth)) // Создаем объект Pen для рисования
			{
				// Рисуем треугольник как равнобедренный (для упрощения)
				Point[] points = 
				{
				new Point(StartX, StartY), // Первая точка
                new Point(StartX + (int)SideA, StartY), // Вторая точка
                new Point(StartX + (int)SideA / 2, StartY - (int)Math.Sqrt(SideA * SideA - (SideA / 2) * (SideA / 2))) // Третья точка
				};
				e.Graphics.DrawPolygon(pen, points); // Рисуем треугольник с помощью этих точек
			}
		}	
	}
}
