using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	[Serializable]
	internal class Teacher:Human
	{
		public string Speciality { get; set; }
		int experience;
		public int Experience
		{
			get=>experience;
			set=>experience=value<70?value:70; 
		}
		public Teacher
			(
			string lastName, string firstName, uint age,
			string speciality,
			int experience
			) : base(lastName, firstName, age)
		{
				Speciality = speciality;
				Experience = experience;
            Console.WriteLine($"TConstructor:\t{GetHashCode()}");
        }
		public Teacher(Human human, string speciality, int experience) : base(human)
		{
			init(speciality, experience);
			Console.WriteLine($"TConstructor:\t{GetHashCode()}");
		}
		~Teacher() { Console.WriteLine($"TDestructor:\t{GetHashCode()}"); }

		void init(string speciality, int experience)
		{
			Speciality = speciality;
			Experience = experience;
		}
		public void Print()
		{
			base.Print();
			Console.WriteLine($"{Speciality}, {Experience}");
		}
		public override string ToString()
		{
			return base.ToString()+$": {Speciality}, {Experience}";
		}
	}
}
