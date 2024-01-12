using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cproject
{
    public class Program
        
        {
            static List<Teacher> teachers = new List<Teacher>();
            static string filePath = @"D:\Mphasis\mproject\TeacherData.txt";
        internal class Teacher
        {

            public int ID { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string Section { get; set; }

            public override string ToString()
            {
                return $"{ID},{Name},{Class},{Section}";
            }
        }

        static void Add_Teacher()
            {
                Teacher teacher = new Teacher();

                Console.Write("Enter ID: ");
                teacher.ID = int.Parse(Console.ReadLine());

                Console.Write("Enter Teacher Name : ");
                teacher.Name = Console.ReadLine();

                Console.Write("Enter Teacher Class : ");
                teacher.Class = Console.ReadLine();

                Console.Write("Enter Teacher Section : ");
                teacher.Section = Console.ReadLine();

                teachers.Add(teacher);
                Console.WriteLine("Teacher added successfully.");
            }
            static void Update_Teacher()
            {
                Console.Write("Enter Teacher ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Teacher teacherToUpdate = teachers.Find(t => t.ID == id);

                if (teacherToUpdate != null)
                {
                    Console.Write("Enter updated Teacher Name: ");
                    teacherToUpdate.Name = Console.ReadLine();

                    Console.Write("Enter updated Teacher Class: ");
                    teacherToUpdate.Class = Console.ReadLine();

                    Console.Write("Enter updated Teacher Section: ");
                    teacherToUpdate.Section = Console.ReadLine();

                    Console.WriteLine("Teacher updated successfully.");
                }
                else
                {
                    Console.WriteLine("Teacher is not found.");
                }
            }

            static void Display_Teachers()
            {
                Console.WriteLine("Teacher Data as follows:");

                foreach (var teacher in teachers)
                {

                    Console.WriteLine($"ID      : {teacher.ID}");
                    Console.WriteLine($"Name    : {teacher.Name}");
                    Console.WriteLine($"Class   : {teacher.Class} ");
                    Console.WriteLine($"Section : {teacher.Section} ");
                }
            }

            static void LoadData()
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (var line in lines)
                    {
                        string[] values = line.Split(',');
                        Teacher teacher = new Teacher
                        {
                            ID = int.Parse(values[0]),
                            Name = values[1],
                            Class = values[2],
                            Section = values[3]
                        };

                        teachers.Add(teacher);
                    }
                }
            }
            static void Save_Data()
            {
                List<string> lines = new List<string>();

                foreach (var teacher in teachers)
                {
                    lines.Add(teacher.ToString());
                }

                File.WriteAllLines(filePath, lines);
            }
            static void Main(string[] args)
            {
                string Choice;
                LoadData();

                do
                {

                    Console.WriteLine("Enter 1 to add Teacher");
                    Console.WriteLine("Enter 2 to upadte Teacher");
                    Console.WriteLine("Enter 3 to Display All Teacher");
                    Console.WriteLine("Enter 4 to Exit");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Add_Teacher();
                            break;

                        case 2:
                            Update_Teacher();
                            break;

                        case 3:
                            Display_Teachers();
                            break;

                        case 4:
                            Save_Data();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                    Console.WriteLine("Do you Continue  yes/no?");
                    Choice = Console.ReadLine();
                }
                while (Choice == "yes");

            }
        }
    }