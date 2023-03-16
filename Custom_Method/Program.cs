using Custom_Method.Services;
using System;

namespace Custom_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService studentServices = new StudentService();
            TeacherService teacherServices = new TeacherService();
            STARTPROGRAM:
            Console.ForegroundColor= ConsoleColor.DarkBlue;
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Edit Student");
            Console.WriteLine("3. Show Student");
            Console.WriteLine("4. Remove Student");
            Console.WriteLine("5. Add Teacher");
            Console.WriteLine("6. Edit Teacher");
            Console.WriteLine("7. Show Teacher");
            Console.WriteLine("8. Remove Teacher");

            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    studentServices.Create(); break;
                case "2":
                    studentServices.Update(); break;
                case "3":
                    studentServices.Show(); break;
                case "4":
                    studentServices.Delete(); break;
                case "5":
                    teacherServices.Create(); break;
                case "6":
                    teacherServices.Update(); break;
                case "7":
                    teacherServices.Show(); break;
                case "8":
                    teacherServices.Delete(); break;
                    default:
                    Console.WriteLine("Duzgun daxil edin ");
                    goto STARTPROGRAM;
            }
            goto STARTPROGRAM;

        }
    }
}
