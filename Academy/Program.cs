//#define INGERITANCE_1
//#define INGERITANCE_2
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Program
	{
		readonly static string delimiter = "\n--------------------------------------------\n";
		static void Main(string[] args)
		{

#if INGERITANCE_1
		    Human human = new Human("Montana", "Antonio", 25);
			human.Print();
			Console.WriteLine(human);
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 25, "Chemestry", "WW_220", 95, 97);
			student.Print();
			Console.WriteLine(student);
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Print();
			Console.WriteLine(teacher);
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Schreader", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg");
			graduate.Print();
			Console.WriteLine(graduate);
			Console.WriteLine(delimiter);

			Human graduate1 = new Graduate("Schreader", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg");
			graduate1.Print();
			Console.WriteLine(graduate1);
			Console.WriteLine(delimiter); 
#endif

#if INGERITANCE_2
			Human tommy = new Human("Vercetty", "Tommy", 30);
			Console.WriteLine(tommy);

			Human ken = new Human("Rozenberg", "Ken", 35);
			Console.WriteLine(ken);

			Human diaz = new Human("Diaz", "Ricardo", 50);
			Console.WriteLine(diaz);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 98, 99);
			Console.WriteLine(s_tommy);

			Student s_ken = new Student(ken, "Lawer", "Vice", 42, 35);
			Console.WriteLine(s_ken);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			Console.WriteLine(g_tommy);

			Teacher t_diaz = new Teacher(diaz, "Weapons distribution", 20);
			Console.WriteLine(t_diaz);
#endif
			//Generalization
			Human[] group = new Human[]
			{
				new Student("Pinkman", "Jessie", 25, "Chemestry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Schreader", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg")
			};
			//Specialization
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
            }
			string Patch=AppDomain.CurrentDomain.BaseDirectory;// Получаем путь к директории проекта
			string fileName = "Group.txt";
			string filePatch = Patch + fileName;
            Console.WriteLine(filePatch);
			
			//SAVE
			//StreamWriter wr = new StreamWriter(filePatch)
			using (StreamWriter sw=new StreamWriter(filePatch))
			{
				for (int i = 0; i < group.Length; i++)
				{
					sw.WriteLine(group[i]);
					
				}
			}
			//wr.Close();

			//Консольный вывод
			Console.WriteLine(delimiter);
			string[] str1=File.ReadAllLines(filePatch);// Чтение всех строк из файла в массив
			for (int i = 0;i < str1.Length;i++)
			{
				Console.WriteLine(str1[i]);
            }
            Console.WriteLine(delimiter);

            using (StreamReader sr=new StreamReader(filePatch))
			{
				string str;
				while((str = sr.ReadLine()) != null)
				{
                    Console.WriteLine(str);
                }
			}
            Console.WriteLine(delimiter);
			
			
			//чтение для объектов
			List<Human>group2=new List<Human>();
			if (!File.Exists(filePatch))
			{
				Console.WriteLine("ошибка открытия фаила");
				return;
			}
			//StreamReader sr1=null;
			using(StreamReader sr1=new StreamReader(filePatch))
			{
				//sr1 = new StreamReader(filePatch);
				string strRead;
				while ((strRead = sr1.ReadLine()) != null)
				{
					string[] Bf = strRead.Split(new[] { ' ', ':', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
					if (Bf.Length == 0) continue;
					if (Bf[0] == "Academy.Student")
					{
						Student student = new Student
							(
							Bf[1],                      // LastName
							Bf[2],                      // FirstName
							Convert.ToUInt32(Bf[3]),     // Age
							Bf[4],                      // Speciality
							Bf[5],                      // Group
							Convert.ToDouble(Bf[6]),    // Rating
							Convert.ToDouble(Bf[7])     // Attendance
							);
						group2.Add(student);
					}
					else if (Bf[0] == "Academy.Teacher")
					{
						// Создаем объект типа Teacher
						Teacher teacher = new Teacher
							(
							Bf[1],							// LastName
							Bf[2],							// FirstName
							Convert.ToUInt32(Bf[3]),		// Age
							Bf[4],							// Speciality
							Convert.ToInt32(Bf[5])			// Experience
							);
						group2.Add(teacher); // Добавляем объект в список
					}
					else if (Bf[0] == "Academy.Graduate")
					{
						// Создаем объект типа Graduate
						Graduate graduate = new Graduate
							(
							Bf[1],						// LastName
							Bf[2],						// FirstName
							Convert.ToUInt32(Bf[3]),	// Age
							Bf[4],						// Speciality
							Bf[5],						// Group
							Convert.ToDouble(Bf[6]),	// Rating
							Convert.ToDouble(Bf[7]),	// Attendance
							Bf[8]						// Subject
							);
						group2.Add(graduate); // Добавляем объект в список
					}
				}
			}
			//finally
			//{
			//	// Закрываем файл, если он был открыт
			//	if (sr1 != null)
			//	{
			//		sr1.Close();
			//	}
			//}
			Console.WriteLine(delimiter);
            Console.WriteLine(delimiter);
            foreach (var item in group2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(delimiter);
            Console.WriteLine(delimiter);


			//Бинарный файл
			string biFilePatch = "Group.dat";
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream fs = new FileStream(biFilePatch, FileMode.OpenOrCreate))
			{
				bf.Serialize(fs, group);
                Console.WriteLine("Запечатали");
            }
			
			Human[] DeGroup;
			using (FileStream fs = new FileStream(biFilePatch, FileMode.Open))
			{
				DeGroup = (Human[])bf.Deserialize(fs);
                Console.WriteLine("распечатали");
            }
           
			Console.WriteLine("===============================================");
            foreach (var item in DeGroup )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===============================================");
        }
	}
}
