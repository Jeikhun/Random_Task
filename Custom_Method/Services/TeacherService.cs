using Custom_Method.Core.Models;
using Custom_Method.Extensions;
using Custom_Method.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Custom_Method.Services
{
    internal class TeacherService : IService, ITeacherService
    {
        Teacher[] teachers = { }; 
        public void Create()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            while (!name.Check_Method())
            {
                Console.Write("Duzgun daxil edin: ");
                name = Console.ReadLine();
            }
            Console.Write("Surname: ");
            string Surname = Console.ReadLine();
            while (!Surname.Check_Method())
            {
                Console.Write("Duzgun daxil edin: ");
                Surname = Console.ReadLine();
            }
            Console.Write("Group ID: ");
            string GroupID = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(GroupID))
            {

                Console.Write("Duzgun daxil edin: ");
                GroupID = Console.ReadLine();
            }
            Teacher teacher = new Teacher()
            {
                Surname = Surname,
                Name = name,
                GroupNumber = GroupID
            };
            Array.Resize(ref teachers, teachers.Length + 1);
            teachers[teachers.Length - 1] = teacher;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{teacher.Name} Elave edildi...");

        }

        public void Delete()
        {
        
            Console.Write("Silmek istediyiniz ID daxil edin: ");
            AGAIN:
            int id = int.Parse(Console.ReadLine());
            Teacher remove;
            int Count = 0;
            for (int i = 0; i < teachers.Length; i++)
            {
                if (teachers[i].Id == id)
                {
                    Count++;
                    remove = teachers[i];
                    teachers[i] = teachers[teachers.Length - 1];
                    teachers[teachers.Length - 1] = remove;
                    Array.Resize(ref teachers, teachers.Length - 1);
                }
            }
            if (teachers.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Silinecek teacher yoxdur");
            }
            else if (Count == 0)
            {
                Console.Write("Duzgun id daxil edin: ");
                goto AGAIN;
            }
        }

        public void Show()
        {
            foreach (var item in teachers)
            {
                Console.Write($"Name: {item.Name}, Surname {item.Surname}, ID {item.Id}");
            }
        }

        public void Update()
        {
            Console.Write("Editleyeceyiniz Teacher ID: ");
            EDITID:
            int EditId = int.Parse(Console.ReadLine());
            if(teachers.Length > 0)
            {


                for (int i = 0; i < teachers.Length; i++)
                {

                    if (teachers[i].Id == EditId)
                    {
                        Console.Write("New name: ");
                        string NewName = Console.ReadLine();
                        while (!NewName.Check_Method())
                        {
                            Console.Write("Duzgun Name daxil edin: ");
                            NewName = Console.ReadLine();
                        }
                        teachers[i].Name = NewName;
                        string NewSurname = Console.ReadLine();
                        while (!NewSurname.Check_Method())
                        {
                            Console.Write("Duzgun Surname daxil edin: ");
                            NewSurname = Console.ReadLine();
                        }
                        teachers[i].Surname = NewSurname;
                        Console.Write("Group name: ");
                        string NewGroupName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(NewGroupName))
                        {
                            Console.Write("Duzgun daxil edin: ");
                            NewGroupName = Console.ReadLine();
                        }
                        teachers[i].GroupNumber = NewGroupName;
                    }
                    else
                    {
                        Console.Write("Duzgun id daxil edin: ");
                        goto EDITID;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Editlenecek teacher yoxdur");
            }
        }
    }
}
