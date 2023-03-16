using Custom_Method.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Method.Core.Models;
using Custom_Method.Extensions;

namespace Custom_Method.Services
{
    internal class StudentService : IService, IStudentService
    {
        Student[] students = { }; 
        public void Create()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Name: ");
            string name = Console.ReadLine();
            while (!name.Check_Method())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Duzgun daxil edin: ");
                name= Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Surname: ");
            string Surname = Console.ReadLine();
            while (!Surname.Check_Method())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Duzgun daxil edin: ");
                Surname = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Group ID: ");
            string GroupID = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(GroupID))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Duzgun daxil edin: ");
                GroupID = Console.ReadLine();
            }
            Student student = new Student()
            {
                Surname = Surname,
                Name = name,
                GroupNumber = GroupID
            };
            Array.Resize(ref students, students.Length + 1);
            students[students.Length-1]=student;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{student.Name} Elave edildi...");

        }

        public void Delete()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Silmek istediyiniz ID daxil edin: ");
            AGAIN:
            int id = int.Parse(Console.ReadLine());
            Student remove;
            int count = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Id == id)
                {
                    count++;
                    remove = students[i];
                    students[i] = students[students.Length-1];
                    students[students.Length - 1] = remove;
                    Array.Resize(ref students, students.Length-1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{students[i].Name} Silindi...");
                }
            }
            if (students.Length==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Silinecek telebe yoxdur");
            }
            else if (count==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Duzgun id daxil edin: ");
                goto AGAIN;
            }
        }

        public void Show()
        {
            foreach (var item in students)
            {
                
                Console.WriteLine($"Name: {item.Name}, Surname {item.Surname}, ID {item.Id}");
            }
        }

        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Editleyeceyiniz Student ID: ");
            EDITID:
            int EditId = int.Parse(Console.ReadLine());
            for (int i = 0; i < students.Length; i++)
            {
                if (students.Length > 0)
                {
                    if (students[i].Id == EditId)
                    {
                        Console.Write("New name: ");
                        string NewName = Console.ReadLine();
                        while (!NewName.Check_Method())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Duzgun Name daxil edin: ");
                            NewName = Console.ReadLine();
                        }
                        students[i].Name = NewName;
                        string NewSurname = Console.ReadLine();
                        while (!NewSurname.Check_Method())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Duzgun Surname daxil edin: ");
                            NewSurname = Console.ReadLine();
                        }
                        students[i].Surname = NewSurname;
                        Console.Write("Group name: ");
                        string NewGroupName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(NewGroupName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Duzgun daxil edin: ");
                            NewGroupName = Console.ReadLine();
                        }
                        students[i].GroupNumber = NewGroupName;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{students[i].Name} editlendi...");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Duzgun id daxil edin: ");
                        goto EDITID;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Student yoxdur");
                }
                
            }
        }
    }
}
